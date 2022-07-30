<template>
    <div class="container">
        <div class="form-group">
            <label>Ürün Adı</label>
            <input id="txtName" class="form-control" v-model="name">
            <small class="form-text text-danger" v-if="validations.name">Ürün adı zorunludur</small>
        </div>
        <div class="form-group mt-2">
            <label>Kategori</label>
            <select id="cmbCategory" class="form-control" v-model="categoryId">
                <option v-for="o in categories" :key="o.id" :value="o.id">{{ o.name }}</option>
            </select>
            <small class="form-text text-danger" v-if="validations.category">Kategori zorunludur</small>
        </div>
        <div class="form-group mt-2">
            <label>Fiyat</label>
            <input id="txtPrice" class="form-control" v-model="price">
            <small class="form-text text-danger" v-if="validations.price">Fiyat zorunludur</small>
        </div>
        <div class="form-group mt-2">
            <label>Miktar</label>
            <input id="txtAmount" class="form-control" v-model="amount">
            <small class="form-text text-danger" v-if="validations.amount">Miktar zorunludur</small>
        </div>
        <button id="btnSave" class="btn btn-primary mt-5" @click="save">Kaydet</button>
    </div>
</template>

<script>
import axios from "axios";
export default {
    name: "New",
    data() {
        return {
            name: null,
            categoryId: null,
            categories: [
                { id: 1, name: "İçecek" },
                { id: 2, name: "Tatlı" },
                { id: 3, name: "Süt Ürünü" },
                { id: 4, name: "Deniz Mahsulü" },
                { id: 5, name: "Tahıl" },
            ],
            price: null,
            amount: null,
            validations: {
                name: false,
                category: false,
                amount: false, 
                price: false
            }
        }
    },
    methods: {
        save() {
            if (this.isInvalid()) {
                return;
            }
            const data = {
                name: this.name,
                price: this.price,
                amount: this.amount,
                categoryId: this.categoryId
            };
            axios.post("https://localhost:7000/api/product", data).then(() => {
                alert("Kayıt Başarılı");
            });
        },
        isInvalid() {
            this.validations.name = false;
            this.validations.category = false;
            this.validations.amount = false;
            this.validations.price = false;
            let invalid = false;
            if(!this.name) {
                this.validations.name = true;
                invalid = true;
            }
            if(!this.categoryId) {
                this.validations.category = true;
                invalid = true;
            }
            if(!this.amount) {
                this.validations.amount = true;
                invalid = true;
            }
            if(!this.price) {
                this.validations.price = true;
                invalid = true;
            }

            return invalid;
        }
    }
}
</script>