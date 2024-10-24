
# Nv Query Request

## Structure

`NvQueryRequest`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `Number` | `string` | Required | Subscriber's MSISDN to be checked. Multiple numbers can be queried using commas, max 30 per request. |

## Example (as JSON)

```json
{
  "number": "19876543210,12345678900"
}
```

