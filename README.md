# Pokemon Store - Pricing Calculator

A Windows Forms desktop application that calculates the total price for Pokemon purchases with tiered bulk discounts.

Built as a web developer evaluation project at **Kent State University**.

## Pricing

| Pokemon     | Unit Price |
|-------------|-----------|
| Pikachu     | $6.00     |
| Squirtle    | $5.00     |
| Charmander  | $5.00     |

## Discount Tiers

| Condition                        | Discount |
|----------------------------------|----------|
| Buying all 3 types together      | 20% off  |
| Buying any 2 types together      | 10% off  |
| Buying a single type             | No discount |

Discounts are applied greedily: the calculator maximizes the 3-type discount first, then 2-type, then prices the remainder at full cost.

### Example

**Order:** 7 Pikachu, 3 Squirtle, 1 Charmander

| Group              | Qty | Subtotal | Discount | Cost   |
|--------------------|-----|----------|----------|--------|
| All 3 types        | 1   | $16.00   | 20%      | $12.80 |
| Pikachu + Squirtle | 2   | $22.00   | 10%      | $19.80 |
| Pikachu only       | 4   | $24.00   | None     | $24.00 |
| **Total**          |     |          |          | **$56.60** |

## Tech Stack

- **Language:** C#
- **Framework:** .NET Framework 4.5 (Windows Forms)
- **IDE:** Visual Studio 2013+
- **Testing:** MSTest

## Build & Run

1. Open `PokemonStore.sln` in Visual Studio
2. Build the solution (`Ctrl+Shift+B`)
3. Run (`F5`)

## Running Tests

Open Test Explorer in Visual Studio (`Test > Windows > Test Explorer`) and click **Run All**.
