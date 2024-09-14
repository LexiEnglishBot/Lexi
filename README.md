
# Lexi
![Logo](https://github.com/LexiEnglishBot/Lexi/blob/develop/assets/logo/lexi.jpg?raw=true)


## Features

- Learn English vocabs
- Persinal learning curve assist
- Daily quiz


## API Reference

- #### HealthCheck

```http
  GET /Lexi/api/{version}/SayHi
```

| Parameter | Type     | Description                |
| :-------- | :------- | :------------------------- |
| `version` | `int` | **Required**. Your API Reference Version |
## Deployment

To deploy this project run

```bash
  docker compose up -d
```


## Variables

- ### Environment Variables

    To run this project, you will need to add the following environment variables to your .env file

    `ASPNETCORE_ENVIRONMENT`

- ### Appsetting Variables

    To run this project, you will need to add the following environment variables to your appsetting file

    `API_KEY`


## Demo

See this original lexi bot:

[Lexi English Bot](https://t.me/LexiEnglishBot)
## License

[MIT](https://choosealicense.com/licenses/mit/)


## Acknowledgements

 - [Telegram Docs](https://core.telegram.org/bots)
 - [Telegram.Bot Dotnet Package](https://github.com/TelegramBots/Telegram.Bot)


## Contributing

Contributions are always welcome!

See `contributing.md` for ways to get started.

Please adhere to this project's `code of conduct`.


## Screenshots

![App Screenshot](https://github.com/LexiEnglishBot/Lexi/blob/develop/assets/images/screenshots/home/Screenshot%202024-09-14%20235334.png?raw=true)


## Authors

- [@Mohammad Yousefian](https://github.com/MohammadYSF)
- [@Matin Ghanbari](https://github.com/MatinGhanbari)

