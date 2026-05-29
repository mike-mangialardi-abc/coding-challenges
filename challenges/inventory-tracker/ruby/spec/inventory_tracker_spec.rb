RSpec.describe InventoryTracker do
  it "is empty when new" do
    inv = InventoryTracker.new
    expect(inv.stock("A")).to eq(0)
    expect(inv.low_stock_skus(100)).to eq([])
  end

  it "creates a SKU with the given quantity on receive" do
    inv = InventoryTracker.new
    inv.receive("A", 5)

    expect(inv.stock("A")).to eq(5)
  end

  it "accumulates on repeated receives" do
    inv = InventoryTracker.new
    inv.receive("A", 5)
    inv.receive("A", 3)

    expect(inv.stock("A")).to eq(8)
  end

  it "reduces stock on ship" do
    inv = InventoryTracker.new
    inv.receive("A", 5)
    inv.ship("A", 2)

    expect(inv.stock("A")).to eq(3)
  end

  it "allows shipping down to exactly zero" do
    inv = InventoryTracker.new
    inv.receive("A", 5)

    expect { inv.ship("A", 5) }.not_to raise_error
    expect(inv.stock("A")).to eq(0)
  end

  it "raises and leaves stock unchanged when shipping more than available" do
    inv = InventoryTracker.new
    inv.receive("A", 5)

    expect { inv.ship("A", 10) }.to raise_error(ArgumentError)
    expect(inv.stock("A")).to eq(5)
  end

  it "raises when shipping an unknown SKU" do
    inv = InventoryTracker.new

    expect { inv.ship("GHOST", 1) }.to raise_error(ArgumentError)
  end

  it "uses a strictly-less-than boundary for low_stock_skus" do
    inv = InventoryTracker.new
    inv.receive("A", 5); inv.ship("A", 5)  # stock 0
    inv.receive("B", 4)                    # stock 4
    inv.receive("C", 5)                    # stock 5 (at threshold)
    inv.receive("D", 6)                    # stock 6

    expect(inv.low_stock_skus(5)).to eq(%w[A B])
  end

  it "returns low_stock_skus in alphabetical order" do
    inv = InventoryTracker.new
    inv.receive("Zeta", 1)
    inv.receive("Alpha", 1)
    inv.receive("Mu", 1)

    expect(inv.low_stock_skus(10)).to eq(%w[Alpha Mu Zeta])
  end

  it "does not report never-received SKUs" do
    inv = InventoryTracker.new
    expect(inv.low_stock_skus(100)).to eq([])
  end
end
