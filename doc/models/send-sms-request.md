
# Send Sms Request

## Structure

`SendSmsRequest`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `From` | `string` | Required | Sender Name that the message will appear from. Max Length of 15 if numeric, 11 if alphanumeric. |
| `To` | `string` | Required | Mobile number of the recipient. Use a comma to send to multiple numbers, max 30 per request. |
| `Text` | `string` | Required | The message to be sent, either in plain text or Unicode. Max length 5 parts. |
| `Type` | `string` | Required | Indicates the type of message. `0` for Plain text, `1` for Unicode. |
| `Scheduled` | `DateTime?` | Optional | The scheduled date and time for sending the message, formatted in ISO 8601. |

## Example (as JSON)

```json
{
  "from": "YourSenderName",
  "to": "12345678900,19876543210",
  "text": "Hello, this is a test message!",
  "type": "0",
  "scheduled": "12/31/2023 19:35:00"
}
```

