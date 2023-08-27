
# QR Menu Api

This is backend api for [QR Menu App](https://github.com/ugurkiymetli/qr-menu).





## Environment Variables

Using [dotnet user-secrets](https://learn.microsoft.com/en-us/aspnet/core/security/app-secrets?view=aspnetcore-7.0&tabs=linux#enable-secret-storage) to keep secrets.
You can visit the link to setup dotnet user-secrets.

You can add them easily via Visual Studio [gesture](https://learn.microsoft.com/en-us/aspnet/core/security/app-secrets?view=aspnetcore-7.0&tabs=linux#json-structure-flattening-in-visual-studio).

```json
{
    "Jwt:Secret": "jwt_secret",
    "Jwt:Issuer": "ugurkiymetli",
    "Jwt:Audience": "qr-menu",
    "Jwt:ExpiresInDays": "7",
    "MongoDb:ConnectionString": "mongodb+srv://mongo-db:db-password@qr.qcnucca.mongodb.net/?retryWrites=true&w=majority",
    "MongoDb:DatabaseName": "qr-menu",
    "MailConfig:Host": "smtp.mail.com",
    "MailConfig:Port": 999,
    "MailConfig:Username": "mail@mail.com",
    "MailConfig:Password": "mail-password"
}
