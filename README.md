#Print Layer Deploy
 docker build . -t SenderApp 
 docker run -d -p 8080:80 SenderApp

 #Print Layer Local
 npm install
 npm run dev
 build & run web app solution