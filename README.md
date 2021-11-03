# ApiManagersDockerized 
You will need Docker Desktop install
Open your terminal
Browse to the project repo
Build image with follwoing command: docker build -t codeforfun21/apimanagers .
Then run with docker image as a container and assign the port number specified in dockerfile $docker run .p 8080:80 codefun21/apimanagers
You should be able to run the project through localhost port 80 on your browser.
