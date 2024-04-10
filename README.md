### Task 2. Simple backend-frontend app

В папке backend настроен простой контроллер GET /ping -> JSON 'pong'

В папке frontend простая html страница с кнопкой ping, 
при нажатии на которую идет запрос GET /ping, и выводится ответ на экран

Для сборке images ```docker-compose build```

Для их поднятия в kubernetes ```kubectl apply -f config.yml```

Если в ```kubectl get services``` ```kubectl get pods``` ```kubectl get dployment``` все хорошо, 
то frontend должен быть доступен по http://localhost:4000