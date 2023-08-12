`bash
docker build -t razor-pages-movie .
`

`bash
docker run -d -p 8080:80 --name myapp razor-pages-movie
`
