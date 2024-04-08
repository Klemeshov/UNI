import sqlite3

conn = sqlite3.connect('/app/database.db')

print('Connect')

cursor = conn.cursor()

cursor.execute('''CREATE TABLE IF NOT EXISTS users
                  (id INTEGER PRIMARY KEY AUTOINCREMENT,
                   name TEXT,
                   age INTEGER)''')

cursor.execute("INSERT INTO users (name, age) VALUES (?, ?)", ("John Doe", 25))
cursor.execute("INSERT INTO users (name, age) VALUES (?, ?)", ("Jane Smith", 30))

conn.commit()

cursor.execute('SELECT * FROM users')
all_users = cursor.fetchall()
for user in all_users:
    print(user)

conn.close()