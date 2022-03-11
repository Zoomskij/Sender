#Print Layer Deploy
 docker build . -t printlayer 
 docker run -d -p 8080:80 printlayer

 #Print Layer Local
 npm install
 npm run dev
 build & run web app solution