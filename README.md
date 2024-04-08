### Task 1. Basics of containerization

В container1 я создаю sqlite DB

container2 запускает main.py

main.py коннектится к бд, если там нет таблицы users создает ее, добавляет туда 2 новых user, и выводит в консоль всех user

```docker-compose build```
```docker-compose up```

Для запуска docker-compose.yml

Хочу заметить, что после ```docker-compose restart```
в базе будут уже 4 users, а не 2 - что свидетельствет тому, что после умирания контейнера база не обнулилась
