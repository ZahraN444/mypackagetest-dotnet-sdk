
# Custom Header Signature



Documentation for accessing and setting credentials for apiKeyAuth.

## Auth Credentials

| Name | Type | Description | Setter | Getter |
|  --- | --- | --- | --- | --- |
| apikey | `string` | Use your API key for authentication. | `Apikey` | `Apikey` |



**Note:** Auth credentials can be set using `CustomHeaderAuthenticationCredentials` in the client builder and accessed through `CustomHeaderAuthenticationCredentials` method in the client instance.

## Usage Example

### Client Initialization

You must provide credentials in the client as shown in the following code snippet.

```csharp
EasySendSMSAPIClient client = new EasySendSMSAPIClient.Builder()
    .CustomHeaderAuthenticationCredentials(
        new CustomHeaderAuthenticationModel.Builder(
            "apikey"
        )
        .Build())
    .Build();
```


