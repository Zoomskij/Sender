<template>
    <div>
        <el-button type="text" @click="dialogVisible = true">Registration</el-button>

        <el-dialog title="Tips"
                   :visible.sync="dialogVisible"
                   width="30%"
                   :before-close="handleClose">
            <div>
                <div>
                    <el-input placeholder="Логин" v-model="login"></el-input>
                </div>
                <div>
                    <el-input placeholder="Пароль" v-model="password"></el-input>
                </div>
                <div>
                    <el-button v-on:click="registration()">Регистрация</el-button>
                </div>
                <div>
                    {{login}} - {{password}}
                    <br />

                    <span>current - {{user.email}}</span>
                </div>

            </div>

        </el-dialog>
    </div>
</template>

<script>
    export default {
        name: 'p-registration',
        data() {
            return {
                login: '',
                password: '',
                user: [],
                dialogVisible: false
            };
        },
        mounted() {
            console.log('p-login activated');
        },
        methods: {
            registration: function () {
                var self = this;
                var model = {
                    login: this.login,
                    password: this.password
                }
                this.$axios.post('/account/registration', model)
                    .then(function (response) {
                        self.user = response;
                        console.log(response);
                    })
                    .catch(function (error) {
                        self.user = error;
                        console.log(error);
                    });
            },
        }
    };
</script>