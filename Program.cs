using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace Cursach
{
    using System;
    using System.IO;
    using System.Collections.Generic;
    using System.Linq;

    /// Базовый класс для логических функций
    public abstract class LogicFunction
    {
        //Значение символа "склееной" позиции '*'
        public const byte cStarSymb = 2;

        //Дизъюнкции или конъюнкции функции
        public readonly ICollection<byte[]> Terms = new LinkedList<byte[]>();

        //Вычисление значения функции
        public abstract bool Calculate(byte[] X);
    }

    /// <summary>
    /// Дизъюнктивная нормальная форма
    /// </summary>
    public class Dnf : LogicFunction
    {
        public override bool Calculate(byte[] X)
        {
            bool bResult = false;
            foreach (byte[] term in Terms)
            {
                bool bTermVal = true;
                for (int i = 0; i < term.Length; i++)
                {
                    if ((term[i] >= cStarSymb) || (term[i] == X[i])) continue;
                    bTermVal = false;
                    break;
                }
                //bResult |= bTermVal;
                if (bTermVal)
                {
                    bResult = true;
                    break;
                }
            }
            return bResult;
        }
    }

    /// Минимизация логической функции методом Квайна\Мак-Класки
    public class Quine_McCluskey
    {
        //Максимальное кол-во элементов, при котором используется Dictionary,
        //чтобы не произошло переполнение максимальной ёмкости контейнера
        private static readonly int DICT_MAX_ITEMS = 8000000;

        //Коллекция "склеенных" термов
        private readonly Dnf _result = new Dnf();
        public Dnf Result
        {
            get { return _result; }
        }

        //Запуск метода
        public void Start(IEnumerable<byte[]> TermsInput)
        {
            LogicFuncMinimize(TermsInput, _result.Terms);
        }

        //Нахождение минимальной логической функции
        private static void LogicFuncMinimize(
          IEnumerable<byte[]> InpTerms, ICollection<byte[]> OutTerms)
        {
            LinkedList<TreeNodeEnd> OutTemp = new LinkedList<TreeNodeEnd>();
            if (InpTerms.First().Length < 40)
            {
                IDictionary<UInt64, TreeNodeEnd> X1Tree = (InpTerms.Count() < DICT_MAX_ITEMS ?
                  (IDictionary<UInt64, TreeNodeEnd>)(new Dictionary<UInt64, TreeNodeEnd>()) :
                  new SortedDictionary<UInt64, TreeNodeEnd>());
                DeleteDublicatingTerms(InpTerms, X1Tree);
                //Повтор до тех пор пока будут оставаться термы
                while (X1Tree.Count != 0)
                {
                    IDictionary<UInt64, TreeNodeEnd> X2Tree = (X1Tree.Count < DICT_MAX_ITEMS ?
                      (IDictionary<UInt64, TreeNodeEnd>)(new Dictionary<UInt64, TreeNodeEnd>()) :
                      new SortedDictionary<UInt64, TreeNodeEnd>());
                    Skleivanie(X1Tree, X2Tree, OutTemp);
                    X1Tree.Clear();
                    X1Tree = X2Tree;
                    GC.Collect(); //Сборка мусора очень сильно влияет на время работы!!!
                }
            }
            else
            {
                TreeFuncTerm X1Tree = new TreeFuncTerm();
                DeleteDublicatingTerms(InpTerms, X1Tree);
                //Повтор до тех пор пока будут оставаться термы
                while (X1Tree.Count != 0)
                {
                    TreeFuncTerm X2Tree = new TreeFuncTerm();
                    Skleivanie(X1Tree, X2Tree, OutTemp);
                    X1Tree.Clear();
                    X1Tree = X2Tree;
                    GC.Collect(); //Сборка мусора очень сильно влияет на время работы!!!
                }
            }
            ReduceRedundancyTerms(OutTemp, OutTerms);
        }

        //Удаление дубликатов термов из входного списка
        //В выходной словарь добавляются только уникальные термы
        private static void DeleteDublicatingTerms(IEnumerable<byte[]> InX1,
          IDictionary<UInt64, TreeNodeEnd> OutX2Tree)
        {
            OutX2Tree.Clear();
            foreach (byte[] x1 in InX1)
            {
                UInt64 iCode = GetTermCode(x1);
                if (OutX2Tree.ContainsKey(iCode)) continue;
                OutX2Tree.Add(iCode, new TreeNodeEnd(x1, null, null));
            }
        }

        //Удаление дубликатов термов из входного списка
        //В выходное дерево добавляются только уникальные термы
        private static void DeleteDublicatingTerms(IEnumerable<byte[]> InX1,
          TreeFuncTerm OutX2Tree)
        {
            OutX2Tree.Clear();
            foreach (byte[] x1 in InX1)
            {
                OutX2Tree.Add(x1, null, null);
            }
        }

        //Склеивание строк с одним различием
        private static void Skleivanie(
          TreeFuncTerm X1Tree, TreeFuncTerm X2Tree,
          ICollection<TreeNodeEnd> OutResult)
        {
            Dictionary<int, TreeNodeEnd> FindTerms = new Dictionary<int, TreeNodeEnd>();
            TreeNodeEnd x1 = X1Tree.Last;
            while (x1 != null)
            {
                bool bIsSkleiv = false;
                for (int iPos = 0; iPos < x1.Term.Length; iPos++)
                {
                    byte cSymbSav = x1.Term[iPos];
                    if (cSymbSav == LogicFunction.cStarSymb) continue;
                    //Склеивание двух термов с одним различием
                    x1.Term[iPos] = (byte)(1 - cSymbSav);
                    TreeNodeEnd pSkleivNode = X1Tree.Contains(x1.Term);
                    if (pSkleivNode != null)
                    {
                        bIsSkleiv = true;
                        //Проверка, чтобы комбинации термов обрабатывались только по одному разу
                        if (cSymbSav == 1)
                        {
                            x1.Term[iPos] = LogicFunction.cStarSymb;
                            X2Tree.Add(x1.Term, x1, pSkleivNode);
                        }
                    }
                    x1.Term[iPos] = cSymbSav;
                }
                //Добавление на выход тех термов, которые ни с кем не склеились
                if (!bIsSkleiv) OutResult.Add(x1);
                //Переход к следующему листу дерева
                x1 = x1.PrevNode;
            }
        }

        //Возвращает уникальный код для терма
        private static UInt64 GetTermCode(byte[] pTerm)
        {
            UInt64 iMultip = 1, iCode = 0;
            for (int i = 0; i < pTerm.Length; i++)
            {
                iCode += (iMultip * pTerm[i]);
                iMultip *= 3;
            }
            return iCode;
        }

        //Склеивание строк с одним различием
        private static void Skleivanie(
          IDictionary<UInt64, TreeNodeEnd> X1Tree,
          IDictionary<UInt64, TreeNodeEnd> X2Tree,
          ICollection<TreeNodeEnd> OutResult)
        {
            foreach (KeyValuePair<UInt64, TreeNodeEnd> x1 in X1Tree)
            {
                bool bIsSkleiv = false;
                UInt64 iMultip = 1;
                for (int iPos = 0; iPos < x1.Value.Term.Length; iPos++)
                {
                    byte cSymbSav = x1.Value.Term[iPos];
                    if (cSymbSav != LogicFunction.cStarSymb)
                    {
                        UInt64 iCode;
                        if (cSymbSav == 0)
                            iCode = x1.Key + iMultip;
                        else //_if (cSymbSav == 1)
                            iCode = x1.Key - iMultip;
                        TreeNodeEnd pSkleivNode = null;
                        X1Tree.TryGetValue(iCode, out pSkleivNode);
                        if (pSkleivNode != null)
                        {
                            bIsSkleiv = true;
                            //Проверка, чтобы комбинации термов обрабатывались только по одному разу
                            if (cSymbSav == 1)
                            {
                                //Склеивание двух термов с одним различием
                                iCode = x1.Key + iMultip;
                                if (!X2Tree.ContainsKey(iCode))
                                {
                                    x1.Value.Term[iPos] = LogicFunction.cStarSymb; //Метка склеивания
                                    X2Tree.Add(iCode, new TreeNodeEnd(x1.Value.Term, x1.Value, pSkleivNode));
                                    x1.Value.Term[iPos] = cSymbSav;
                                }
                            }
                        }
                    }
                    iMultip *= 3;
                }
                //Добавление на выход тех термов, которые ни с кем не склеились
                if (!bIsSkleiv) OutResult.Add(x1.Value);
            }
        }

        //Отбрасывание избыточных терм с помощью алгоритма приближенного решения задачи о покрытии
        private static void ReduceRedundancyTerms(
          IEnumerable<TreeNodeEnd> SkleivTerms, ICollection<byte[]> ResultTerms)
        {
            //Подготовка результирующего контейнера
            ResultTerms.Clear();
            //Контейнер для соответствия конечного терма к списку первичных термов, которые его образовали
            IDictionary<TreeNodeEnd, HashSet<TreeNodeEnd>> Outputs2Inputs =
              new Dictionary<TreeNodeEnd, HashSet<TreeNodeEnd>>();
            //Контейнер для соответствия первичных входных терм к тем выходным, которые их покрывают
            IDictionary<TreeNodeEnd, HashSet<TreeNodeEnd>> Inputs2Outputs =
              new Dictionary<TreeNodeEnd, HashSet<TreeNodeEnd>>();
            //Сбор статистики об покрытии выходными термами входных
            foreach (TreeNodeEnd outTerm in SkleivTerms)
            {
                //Контейнер входных термов, которые покрывает данный выходной терм term
                HashSet<TreeNodeEnd> InpTermsLst = new HashSet<TreeNodeEnd>();
                HashSet<TreeNodeEnd> ListNumbers = new HashSet<TreeNodeEnd>();
                ListNumbers.Add(outTerm);
                while (ListNumbers.Count > 0)
                {
                    TreeNodeEnd pCurrNode = ListNumbers.First();
                    ListNumbers.Remove(pCurrNode);
                    if (pCurrNode.Parent1 != null && pCurrNode.Parent2 != null)
                    {
                        ListNumbers.Add(pCurrNode.Parent1);
                        ListNumbers.Add(pCurrNode.Parent2);
                    }
                    else
                    {
                        InpTermsLst.Add(pCurrNode);
                        if (!Inputs2Outputs.ContainsKey(pCurrNode))
                        {
                            Inputs2Outputs.Add(pCurrNode, new HashSet<TreeNodeEnd>());
                        }
                        Inputs2Outputs[pCurrNode].Add(outTerm);
                    }
                }
                Outputs2Inputs.Add(outTerm, InpTermsLst);
            }
            //Сортировка словаря исходных термов по возрастанию кол-ва их покрытий выходными
            Inputs2Outputs = Inputs2Outputs.OrderBy(p => p.Value.Count).ToDictionary(p => p.Key, v => v.Value);
            //Перебор всех входных термов, отсортированных по кол-ву покрывавших их выходных
            while (Inputs2Outputs.Count > 0)
            {
                TreeNodeEnd outTerm = Inputs2Outputs.First().Value.OrderByDescending(q => Outputs2Inputs[q].Count()).First();
                ResultTerms.Add(outTerm.Term);
                foreach (TreeNodeEnd inpTerm in Outputs2Inputs[outTerm].ToArray())
                {
                    foreach (TreeNodeEnd outTerm2Del in Inputs2Outputs[inpTerm])
                    {
                        Outputs2Inputs[outTerm2Del].Remove(inpTerm);
                    }
                    Inputs2Outputs.Remove(inpTerm);
                }
            }
        }
    }

    /// <summary>
    /// Дерево термов
    /// </summary>
    public class TreeFuncTerm
    {
        //Корень
        private readonly TreeNodeMiddle rootNode = new TreeNodeMiddle();
        //Ссылка на завершающий узел последовательности конечных листьев дерева
        private TreeNodeEnd _lastTreeNode = null;
        public TreeNodeEnd Last
        {
            get { return _lastTreeNode; }
        }
        //Возвращает количество термов в дереве
        private int _count = 0;
        public int Count
        {
            get { return _count; }
        }

        //Конструктор
        public TreeFuncTerm()
        {
            Clear();
        }

        //Очистить дерево
        public void Clear()
        {
            rootNode.Clear();
            _count = 0;
            _lastTreeNode = null;
        }

        //Добавление в дерево нового терма
        public void Add(byte[] term, TreeNodeEnd pParent1, TreeNodeEnd pParent2)
        {
            TreeNodeMiddle pCurrNode = rootNode;
            int iTermLength1 = term.Length - 1;
            for (int i = 0; i < iTermLength1; i++)
            {
                byte cSymb = term[i];
                TreeNodeBase item = pCurrNode.Childs[cSymb];
                if (item == null)
                {
                    item = new TreeNodeMiddle();
                    pCurrNode.Childs[cSymb] = item;
                }
                pCurrNode = (TreeNodeMiddle)item;
            }
            TreeNodeBase pNewNode = pCurrNode.Childs[term[iTermLength1]];
            if (pNewNode == null)
            {
                pNewNode = new TreeNodeEnd(term, pParent1, pParent2, _lastTreeNode);
                pCurrNode.Childs[term[iTermLength1]] = pNewNode;
                _lastTreeNode = (TreeNodeEnd)pNewNode;
                _count++;
            }
        }

        //Проверка нахождения последовательности в контейнере
        public TreeNodeEnd Contains(byte[] term)
        {
            TreeNodeBase pCurrNode = rootNode;
            foreach (byte cSymb in term)
            {
                pCurrNode = ((TreeNodeMiddle)pCurrNode).Childs[cSymb];
                if (pCurrNode == null) break;
            }
            return ((pCurrNode != null) && (pCurrNode is TreeNodeEnd) ?
              (TreeNodeEnd)pCurrNode : null);
        }
    }

    /// <summary>
    /// Базовый интерфейс узла дерева термов
    /// </summary>
    public interface TreeNodeBase
    {
        //Очистка выделенных ресурсов
        void Clear();
    }

    /// <summary>
    /// Конечный узел дерева термов
    /// </summary>
    public class TreeNodeEnd : TreeNodeBase
    {
        //Терм, сопоставленный узлу
        public readonly byte[] Term;
        //Ссылка на предыдущий конечный узел дерева текущего уровня
        //для создания одностороннего связанного списка
        public readonly TreeNodeEnd PrevNode;
        //Ссылка на родительский конечный узел дерева предыдущего уровня
        public readonly TreeNodeEnd Parent1;
        //Ссылка на родительский конечный узел дерева предыдущего уровня
        public readonly TreeNodeEnd Parent2;

        //Конструктор
        public TreeNodeEnd(byte[] pTermRef, TreeNodeEnd pParent1, TreeNodeEnd pParent2,
          TreeNodeEnd pPrevTreeNode = null)
        {
            pTermRef.CopyTo(Term = new byte[pTermRef.Length], 0);
            Parent1 = pParent1;
            Parent2 = pParent2;
            PrevNode = pPrevTreeNode;
        }

        //Очистка выделенных ресурсов - отсутствует
        public void Clear() { }
    }

    /// Промежуточный узел дерева термов
    public class TreeNodeMiddle : TreeNodeBase
    {
        //Дочерние узлы
        public readonly TreeNodeBase[] Childs = new TreeNodeBase[3];

        //Очистка выделенных ресурсов
        public void Clear()
        {
            for (int i = 0; i < 3; i++)
            {
                if (Childs[i] != null)
                {
                    Childs[i].Clear();
                    Childs[i] = null;
                }
            }
        }
    }




    class Program
    {
        static void Main(string[] args)
        {
           // string s = "001";
            string s1 = "100";
            //string s2 = "101";
            string s3 = "110";
            string s4 = "111";

            ICollection<byte[]> bla = new LinkedList<byte[]>();
           // bla.Add(s.Select(p => (byte)(p == '0' ? 0 : 1)).ToArray());
            bla.Add(s1.Select(p => (byte)(p == '0' ? 0 : 1)).ToArray());
          //  bla.Add(s2.Select(p => (byte)(p == '0' ? 0 : 1)).ToArray());
            bla.Add(s3.Select(p => (byte)(p == '0' ? 0 : 1)).ToArray());
            bla.Add(s4.Select(p => (byte)(p == '0' ? 0 : 1)).ToArray());
            Quine_McCluskey a = new Quine_McCluskey();
            a.Start(bla);
            Console.WriteLine(a.Result.Terms.Count);
            foreach (byte[] i in a.Result.Terms)
            {
                foreach(byte b in i)
                {
                    Console.Write(b);
                }
                Console.WriteLine();
            }
            Console.ReadLine();
        }
    }
}
/*
2
-01
1--
*/
//(a * (b+-c))
//ab + a-c

// 4 глава