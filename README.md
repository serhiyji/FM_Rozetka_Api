# Create react app in docker

Create docker hub repository - publish
```
docker build -t rozetka-api . 
docker run -it --rm -p 5081:8080 --name rozetka_container rozetka-api
docker run -d --restart=always --name rozetka_container -p 5081:8080 rozetka-api
docker run -d --restart=always -v d:/volumes/api/images:/app/images --name rozetka_container -p 5081:8080 rozetka-api
docker run -d --restart=always -v /rozetka/api/images:/app/images --name rozetka_container -p 5081:8080 rozetka-api
docker ps -a
docker stop rozetka_container
docker rm rozetka_container

docker images --all
docker rmi rozetka-api

docker login
docker tag rozetka-api:latest novakvova/rozetka-api:latest
docker push novakvova/rozetka-api:latest

docker pull novakvova/rozetka-api:latest
docker ps -a
docker run -d --restart=always --name rozetka_container -p 5081:8080 novakvova/rozetka-api


docker pull novakvova/rozetka-api:latest
docker images --all
docker ps -a
docker stop rozetka_container
docker rm rozetka_container
docker run -d --restart=always --name rozetka_container -p 5081:8080 novakvova/rozetka-api
```

```nginx options /etc/nginx/sites-available/default
server {
    server_name   mayba.itstep.click *.mayba.itstep.click;
    location / {
       proxy_pass         http://localhost:5081;
       proxy_http_version 1.1;
       proxy_set_header   Upgrade $http_upgrade;
       proxy_set_header   Connection keep-alive;
       proxy_set_header   Host $host;
       proxy_cache_bypass $http_upgrade;
       proxy_set_header   X-Forwarded-For $proxy_add_x_forwarded_for;
       proxy_set_header   X-Forwarded-Proto $scheme;
    }
}

server {
		server_name   techno.itstep.click *.techno.itstep.click;
		root /var/techno.itstep.click;
		index index.html;

		location / {
			try_files $uri /index.html;
			#try_files $uri $uri/ =404;
		}
}

sudo systemctl restart nginx
certbot
```

/var/api-qubix.itstep.click/





