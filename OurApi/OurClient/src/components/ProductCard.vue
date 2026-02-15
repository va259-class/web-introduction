<template>
    <div class="p-card">
        <div class="p-name">
            <h4>{{ value.productName }}</h4>
        </div>
        <div class="p-image">
            <img src="/images/empty-product.png" alt="Northwind Ürünü" />
        </div>
        <div class="p-footer">
            <span class="price">{{ value.unitPrice }} ₺</span>
            <span>{{ value.unitsInStock }}</span>
        </div>
    </div>
</template>

<script>
export default {
    name: "ProductCard",
    props: {
        value: {
            type: Object,
            required: true
        }
    }
}
</script>
<style scoped>
.p-card {
    border: 2px solid #33b3da;
    flex: 0 0 180px;
    border-radius: 10px;
    height: 210px;
    padding: 0px;
    overflow: hidden;
}

.p-card:hover {
    cursor: pointer;
    border: 2px dashed #237791;
}

.p-card .p-name {
    background-color: #4b9fff;
    height: 30px;
    text-align: center;
    line-height: 30px;
    color: #FFF;
}

.p-card .p-image {
    height: 150px;
}

.p-card .p-footer {
    height: 30px;
}

.p-card h4 {
    margin: 0px;
}

.p-footer {
    display: flex;
    justify-content: space-between;
    padding: 0px 10px;
}

.p-footer .price {
    font-weight: bold;
    font-size: 14px;
}

.p-image {
    display: flex;
    justify-content: center;
}

.p-image img {
    width: 120px;
    height: 120px;
}
</style>