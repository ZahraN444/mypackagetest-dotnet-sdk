# API

```csharp
APIController aPIController = client.APIController;
```

## Class Name

`APIController`

## Methods

* [Send Sms](../../doc/controllers/api.md#send-sms)
* [Get Sms Balance](../../doc/controllers/api.md#get-sms-balance)
* [Hlr Query](../../doc/controllers/api.md#hlr-query)
* [Nv Query](../../doc/controllers/api.md#nv-query)


# Send Sms

Send a single SMS message.

```csharp
SendSmsAsync(
    Models.SendSmsRequest body)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `body` | [`SendSmsRequest`](../../doc/models/send-sms-request.md) | Body, Required | - |

## Response Type

[`Task<Models.SendSmsResponse>`](../../doc/models/send-sms-response.md)

## Example Usage

```csharp
SendSmsRequest body = new SendSmsRequest
{
    From = "YourSenderName",
    To = "12345678900,19876543210",
    Text = "Hello, this is a test message!",
    Type = "0",
    Scheduled = DateTime.ParseExact("12/31/2023 19:35:00", "yyyy'-'MM'-'dd'T'HH':'mm':'ss.FFFFFFFK",
        provider: CultureInfo.InvariantCulture,
        DateTimeStyles.RoundtripKind),
};

try
{
    SendSmsResponse result = await aPIController.SendSmsAsync(body);
}
catch (ApiException e)
{
    // TODO: Handle exception here
    Console.WriteLine(e.Message);
}
```

## Errors

| HTTP Status Code | Error Description | Exception Class |
|  --- | --- | --- |
| 400 | Bad request | `ApiException` |
| 401 | Unauthorized | `ApiException` |
| 403 | Forbidden | `ApiException` |
| 429 | Too many requests | `ApiException` |
| 500 | Internal server error | `ApiException` |


# Get Sms Balance

Retrieve the remaining balance for SMS messages.

```csharp
GetSmsBalanceAsync()
```

## Response Type

[`Task<Models.BalanceResponse>`](../../doc/models/balance-response.md)

## Example Usage

```csharp
try
{
    BalanceResponse result = await aPIController.GetSmsBalanceAsync();
}
catch (ApiException e)
{
    // TODO: Handle exception here
    Console.WriteLine(e.Message);
}
```

## Errors

| HTTP Status Code | Error Description | Exception Class |
|  --- | --- | --- |
| 400 | Bad request | `ApiException` |
| 401 | Unauthorized | `ApiException` |
| 403 | Forbidden | `ApiException` |
| 429 | Too many requests | `ApiException` |
| 500 | Internal server error | `ApiException` |


# Hlr Query

Perform an HLR (Home Location Register) query to check the status of a phone number.

```csharp
HlrQueryAsync(
    Models.HlrQueryRequest body)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `body` | [`HlrQueryRequest`](../../doc/models/hlr-query-request.md) | Body, Required | - |

## Response Type

[`Task<Models.HlrQueryResponse>`](../../doc/models/hlr-query-response.md)

## Example Usage

```csharp
HlrQueryRequest body = new HlrQueryRequest
{
    Number = "19876543210,12345678900",
};

try
{
    HlrQueryResponse result = await aPIController.HlrQueryAsync(body);
}
catch (ApiException e)
{
    // TODO: Handle exception here
    Console.WriteLine(e.Message);
}
```

## Errors

| HTTP Status Code | Error Description | Exception Class |
|  --- | --- | --- |
| 400 | Bad request | `ApiException` |
| 401 | Unauthorized | `ApiException` |
| 403 | Forbidden | `ApiException` |
| 429 | Too many requests | `ApiException` |
| 500 | Internal server error | `ApiException` |


# Nv Query

Perform a Number Validation (NV) query to validate a phone number.

```csharp
NvQueryAsync(
    Models.NvQueryRequest body)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `body` | [`NvQueryRequest`](../../doc/models/nv-query-request.md) | Body, Required | - |

## Response Type

[`Task<Models.NvQueryResponse>`](../../doc/models/nv-query-response.md)

## Example Usage

```csharp
NvQueryRequest body = new NvQueryRequest
{
    Number = "19876543210,12345678900",
};

try
{
    NvQueryResponse result = await aPIController.NvQueryAsync(body);
}
catch (ApiException e)
{
    // TODO: Handle exception here
    Console.WriteLine(e.Message);
}
```

## Errors

| HTTP Status Code | Error Description | Exception Class |
|  --- | --- | --- |
| 400 | Bad request | `ApiException` |
| 401 | Unauthorized | `ApiException` |
| 403 | Forbidden | `ApiException` |
| 429 | Too many requests | `ApiException` |
| 500 | Internal server error | `ApiException` |

