<template>
    <div>
        <el-table :data="reviews"
                  style="width: 100%">
            <el-table-column prop="id"
                             label="Id"
                             width="180">
            </el-table-column>
            <el-table-column prop="username"
                             label="UserName"
                             width="180">
            </el-table-column>
            <el-table-column prop="description"
                             label="Description">
            </el-table-column>
            <el-table-column prop="grade"
                             label="Grade">
            </el-table-column>
        </el-table>

        <el-row>
            <el-button v-on:click="addReview()">add review component</el-button>
        </el-row>
    </div>
</template>

<script>
    export default {
        name: 'root',
        data() {
            return {
                reviews: []
            }
        },
        computed: {

        },
        methods: {
            getReviews: function () {
                var self = this;
                this.$axios.get('/reviews', {
                    headers: {
                        'Content-Type': 'application/json'
                    }
                })
                    .then(function (response) {
                        self.reviews = response.data;
                        console.log(response);
                    })
                    .catch(function (error) {
                        console.log(error);
                    });
            },
            addReview: function () {
                var self = this;

                var review = {
                    grade: 4,
                    description: 'This is a test description!'
                }

                this.$axios({
                    method: 'post',
                    url: '/reviews/add',
                    data: review
                })
                    .then(function (response) {
                        console.log(response);
                    })
                    .catch(function (error) {
                        console.log(error);
                    });
            }
        },
        mounted() {
            this.getReviews();
        }
    }
</script>