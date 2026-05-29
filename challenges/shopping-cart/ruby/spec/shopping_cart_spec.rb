RSpec.describe ShoppingCart do
  it "is empty when new" do
    cart = ShoppingCart.new
    expect(cart.total).to eq(0)
    expect(cart.item_count).to eq(0)
  end

  it "tracks item count and total when an item is added" do
    cart = ShoppingCart.new
    cart.add_item("Apple", 1.50, 2)

    expect(cart.item_count).to eq(1)
    expect(cart.total).to eq(3.00)
  end

  it "sums two different items correctly" do
    cart = ShoppingCart.new
    cart.add_item("Apple", 1.50, 2)
    cart.add_item("Bread", 3.00, 1)

    expect(cart.item_count).to eq(2)
    expect(cart.total).to eq(6.00)
  end

  it "increases quantity when the same item name is added twice" do
    cart = ShoppingCart.new
    cart.add_item("Apple", 1.50, 2)
    cart.add_item("Apple", 1.50, 3)

    expect(cart.item_count).to eq(1)
    expect(cart.total).to eq(7.50)
  end

  it "removes an item by name" do
    cart = ShoppingCart.new
    cart.add_item("Apple", 1.50, 2)
    cart.add_item("Bread", 3.00, 1)

    cart.remove_item("Apple")

    expect(cart.item_count).to eq(1)
    expect(cart.total).to eq(3.00)
  end

  it "treats removing a missing item as a no-op" do
    cart = ShoppingCart.new
    cart.add_item("Apple", 1.50, 2)

    expect { cart.remove_item("Ghost") }.not_to raise_error
    expect(cart.item_count).to eq(1)
    expect(cart.total).to eq(3.00)
  end

  it "applies SAVE10 to take 10% off" do
    cart = ShoppingCart.new
    cart.add_item("Widget", 100.00, 1)
    cart.apply_discount_code("SAVE10")

    expect(cart.total).to eq(90.00)
  end

  it "replaces the active discount code when a new one is applied" do
    cart = ShoppingCart.new
    cart.add_item("Widget", 10.00, 1)

    cart.apply_discount_code("HALFOFF")
    expect(cart.total).to eq(5.00)

    cart.apply_discount_code("SAVE20")
    expect(cart.total).to eq(8.00)
  end

  it "raises on unknown code and keeps the existing code" do
    cart = ShoppingCart.new
    cart.add_item("Widget", 100.00, 1)
    cart.apply_discount_code("SAVE10")

    expect { cart.apply_discount_code("BOGUS") }.to raise_error(ArgumentError)

    # SAVE10 must still be in effect.
    expect(cart.total).to eq(90.00)
  end

  it "rounds total to 2 decimal places" do
    cart = ShoppingCart.new
    cart.add_item("Widget", 9.99, 1)
    cart.apply_discount_code("SAVE10")

    # 9.99 * 0.9 = 8.991 -> rounds to 8.99.
    expect(cart.total).to eq(8.99)
  end
end
