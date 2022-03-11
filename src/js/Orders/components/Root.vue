<template>
    <div>
        <el-table :data="orders"
                  style="width: 100%">
            <el-table-column prop="id"
                             label="Id"
                             width="180">
            </el-table-column>
            <el-table-column prop="status"
                             label="Status"
                             width="180">
            </el-table-column>
            <el-table-column prop="address"
                             label="Address">
            </el-table-column>
            <el-table-column prop="phone"
                             label="Phone">
            </el-table-column>
            <el-table-column prop="description"
                             label="Description">
            </el-table-column>
        </el-table>
    </div>
</template>

<script>
    export default {
        name: 'root',
        data() {
            return {
                orders: []
            }
        },
        computed: {

        },
        methods: {
            getOrders: function () {
                var self = this;
                this.$axios.get('/orders', {
                    headers: {
                        'Content-Type': 'application/json'
                    }
                })
                    .then(function (response) {
                        self.orders = response.data;
                        console.log(response);
                    })
                    .catch(function (error) {
                        console.log(error);
                    });
            }
        },
        mounted() {
            this.getOrders();
        }
    }
</script>