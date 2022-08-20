## VulnerableApp4Kubernetes
This project is a .NET Core 3.1 API project that contains critical web security vulnerabilities. It has been developed to detect whether the relevant environment can catch security vulnerabilities when the project is run on a container or cloud environment and when vulnerabilities are triggered.

Since there is a solution(.sln) file in the application, you can run it directly, convert it into an image using Docker file or download it from Dockerhub.

**Dockerhub**
```
docker pull erdemstar/vulnerableapp4kubernetes:1.0.0
```

## Vulnerabilities
The vulnerabilities of the application are as follows.
 - Remote Code Execution
 - File Inclusion
 - File Delete
 - File Upload
 - Server Side Request Forgery
 - XML External Entity (Soon)
 - Reflected XSS
 - Open URL Redirect


## Contributing
Pull requests are welcome. For major changes, please open an issue first to discuss what you would like to change.

## License
[MIT](https://choosealicense.com/licenses/mit/)
