Email Sending with Attachments Feature
This project includes functionality for sending emails with attachments in an ASP.NET Core application. Users can send emails with one or more file attachments through an SMTP server. The email content and attachments are customizable, and this feature can be integrated into any system requiring automatic email notifications or reports with file attachments.

Key Features:
Send Emails with Multiple Attachments:

Allows users to send emails with multiple file attachments (e.g., PDFs, images, spreadsheets).

Users can send dynamic content (like text, HTML, etc.) in the body of the email.

SMTP Integration:

The email service integrates with any SMTP server (e.g., Gmail, Outlook, custom SMTP server).

Uses MailKit and MimeKit libraries to facilitate sending and attaching files to emails securely and efficiently.

Configurable Email Settings:

SMTP server configuration is stored in the appsettings.json file, allowing users to specify their email provider’s SMTP server and authentication details.

Email Body Customization:

The email body can be customized as plain text or HTML, allowing rich-text content in the email body.

Attachments are automatically included based on file paths provided.

The email can be sent to a single recipient.

Async Email Sending:

The email sending process is done asynchronously to avoid blocking the application’s main thread, ensuring that users can continue working while emails are being sent.
