function fillDemoAsset() {
    const manufacturers = ["Dell", "HP", "Lenovo", "Apple"];
    const models = ["Latitude 5420", "EliteDesk 800", "ThinkPad X1", "MacBook Pro 14", "PowerEdge R740"];
    const manufacturer = manufacturers[Math.floor(Math.random() * manufacturers.length)];
    const model = models[Math.floor(Math.random() * models.length)];

    document.getElementById('Name').value = manufacturer + " " + model;
    document.getElementById('SerialNumber').value = 'SN-' + Math.floor(100000 + Math.random() * 900000);
    document.getElementById('Model').value = model;
    document.getElementById('Manufacturer').value = manufacturer;

    const purchaseDate = new Date();
    purchaseDate.setFullYear(purchaseDate.getFullYear() - Math.floor(Math.random() * 3));
    document.getElementById('PurchaseDate').value = purchaseDate.toISOString().split('T')[0];

    const warrantyDate = new Date(purchaseDate);
    warrantyDate.setFullYear(warrantyDate.getFullYear() + 1 + Math.floor(Math.random() * 3));
    document.getElementById('WarrantyExpirationDate').value = warrantyDate.toISOString().split('T')[0];

    document.getElementById('PurchasePrice').value = (Math.random() * 2000 + 200).toFixed(2);

    const statusSelect = document.getElementById('Status');
    statusSelect.selectedIndex = Math.floor(Math.random() * statusSelect.options.length);

    document.getElementById('CustomFieldsJson').value = 'Location=Toronto;Department=IT';

    const categorySelect = document.getElementById('CategoryId');
    if (categorySelect.options.length > 0) {
        categorySelect.selectedIndex = Math.floor(Math.random() * categorySelect.options.length);
    }
}