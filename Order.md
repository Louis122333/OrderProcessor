# Order Processing Documentation

This documentation explains the process flow of handling order data, including its raw format, transformation into C# classes, and the final JSON output format.

## 1. Raw Format (Unprocessed Order Data)

The input files contain raw order data in a specific text format. Each order starts with a header line (`H`), followed by one or more rows (`R`), and ends with an end marker (`E`).

### Order text (Raw format)
```
H 44167    42-3   2019-01-03   4    Södra härene             0532-4312104   
R 4635388  S    6     699.00     499.00     GREEN                                          
R 5854839  S    9     699.00     499.00     BLACK            1234-ff-56                    
R 3654389  M    1     549.00     449.00     GREEN/BLACK      1234-ff-56                    
R 1205949  XL   4     100.00     49.00      BLUE             1234-ff-56                    
R 4659304  XL   7     185.00     75.00      RED/BLACK        1234-ff-56                    
R 0909432  XXL  16    699.00     499.00     RED/BLACK        1234-ff-56                    
R 4321723  S    20    1699.00    1499.00    WHITE            1234-ff-56                    
E
H 44168    03-1   2019-01-03   4    Hemlemossevägen          0921-9348287   
R 2432983  152  300   9.99       5.50       13/55                                          
R 9853590  164  1     299.00     199.00     BLACK                                          
R 0977733  72   3     399.00     299.00     49/55                                          
R 9923384  L    11    167.00     103.00     GREEN                                          
E
H 44169    22     2019-01-03   4    Lastageplatsen           026-6428510    
R 4635388  S    6     699.00     499.00     GREEN/BLACK                                    
E
```

### Explanation of the Raw Format:
- **`H` (Header line)**: Contains metadata about the order such as Order Number, Company Code, Order Date, and Customer information.
- **`R` (Row line)**: Contains detailed product information for that specific order, such as Article Number, Size, Quantity, Price, and Color.
- **`E` (End marker)**: Indicates the end of an order.

### Position Details:
- **Order Header (H)**
  - `OrderNumber`: Starts at position 2, length 9
  - `CompanyCode`: Starts at position 11, length 7
  - `OrderDate`: Starts at position 18, length 13
  - `PosNumber`: Starts at position 31, length 5
  - `Address`: Starts at position 36, length 25
  - `Phone`: Starts at position 61, length 15
- **Order Row (R)**
  - `ArticleNumber`: Starts at position 2, length 9
  - `Size`: Starts at position 11, length 5
  - `Quantity`: Starts at position 16, length 6
  - `PriceIncVat`: Starts at position 22, length 11
  - `PriceExcVat`: Starts at position 33, length 11
  - `Color`: Starts at position 44, length 17
  - `Reference`: Starts at position 61, length 30 (optional)

---

## 2. C# Class Representation

Once the raw data is parsed, it is converted into the following C# object models.

### Order Model

```csharp
public class Order
{
    public string OrderNumber { get; set; }
    public string CompanyCode { get; set; }
    public string OrderDate { get; set; }
    public string PosNumber { get; set; }
    public string Address { get; set; }
    public string Phone { get; set; }
    public List<OrderRow> Rows { get; set; }
}
```
### OrderRow Model
```
public class OrderRow
{
    public string ArticleNumber { get; set; }
    public string Size { get; set; }
    public int Quantity { get; set; }
    public decimal PriceIncVat { get; set; }
    public decimal PriceExcVat { get; set; }
    public string Color { get; set; }
    public string? Reference { get; set; }
}
```

## Json Output
After processing the raw text data, the C# objects are serialized into JSON format:
```

{
    "OrderNumber": "",
    "OrderDate": "",
    "CompanyCode": "",
    "PosNumber": "",
    "Address": "",
    "Phone": "",
    "Rows": [
        {
            "ArticleNumber": "",
            "Size": "",
            "Quantity": 0,
            "PriceIncVat": 0,
            "PriceExcVat": 0,
            "Color": "",
            "Reference": ""
        }
    ]
}
```