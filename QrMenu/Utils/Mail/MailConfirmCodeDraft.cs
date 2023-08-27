namespace QrMenu.Utils.Mail
{
    public class MailConfirmCodeDraft
    {
        private const string AppName = "QR Menu App";

        public string Body { get; set; }
        public string Subject { get; set; }

        public MailConfirmCodeDraft(string confirmCode, string username)
        {
            Subject = $"Welcome to {AppName} - Confirm Your Email";
            Body = GenerateBody(confirmCode, username);
        }

        private string GenerateBody(string confirmCode, string username)
        {
            return $@"
                <html>
                    <body style='font-family: Arial, sans-serif;'>
                        <h1>Welcome to <span style='color: #3498db;'>{AppName}</span></h1>
                        <p>
                            Thank you, <span style='font-weight: bold;'>{username}</span>, for registering with <span style='color: #3498db;'>{AppName}</span>! To complete your registration, please confirm your email address.
                        </p>
                        <p>
                            Here's your confirmation code: <span style='font-weight: bold; color: #e74c3c;'>{confirmCode}</span>
                        </p>
                        <p>
                            Please enter this code in the confirmation page to verify your email.
                        </p>
                        <p>
                            If you didn't sign up for <span style='color: #3498db;'>{AppName}</span>, you can safely ignore this email.
                        </p>
                        <p>
                            Best regards,<br>
                            The <span style='color: #3498db;'>{AppName}</span> Team
                        </p>
                    </body>
                </html>
            ";
        }
    }
}
