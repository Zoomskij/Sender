<template>
    <div style="display:flex; justify-content:flex-start">

        <div v-for="item in items" >
            <el-card class="box-card" style="width: 200px">
                <div class="text item" style="padding: 18px 0">
                    {{item.name}}<br />
                    {{item.description}}
                </div>
            </el-card>
        </div>
    </div>
</template>

<script>
    export default {
        name: 'news',
        data() {
            return {
                items: []
            }
        },
        computed: {

        },
        methods: {
            getNews: function () {
                var self = this;
                this.$axios.get('/news', {
                    headers: {
                        'Content-Type': 'application/json'
                    }
                })
                    .then(function (response) {
                        self.items = response.data;
                        console.log(response);
                    })
                    .catch(function (error) {
                        console.log(error);
                    });
            }
        },
        mounted() {
            this.getNews();
        }
    }
</script>

<!--<style>
  .text {
    font-size: 14px;
  }

  .item {
    padding: 18px 0;
  }

  .box-card {
    width: 480px;
  }
</style>-->