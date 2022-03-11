<template>
    <div class="p-footer">
        <div class="p-padding">
            <div class="p-padding">
                <span>© 2022 MyCompanyName</span>
            </div>
            <div class="p-padding">
                <span>ИНН 615428091205</span>
            </div>
            <div class="p-padding">
                <span>ОГРНИП 319619600222564</span>
            </div>
        </div>
        <div class="p-padding">
            <el-link type="primary">Наши работы</el-link>
            <el-divider direction="vertical"></el-divider>
            <el-link type="primary">Цены</el-link>
            <el-divider direction="vertical"></el-divider>
            <el-link type="primary">О наc</el-link>
            <el-divider direction="vertical"></el-divider>
            <el-link type="primary">Вопросы</el-link>
            <el-divider direction="vertical"></el-divider>
            <el-link type="primary">Контакты</el-link>
        </div>
    </div>
</template>

<script>
    export default {
        name: 'print-layer-footer',
        data() {
            return {
               
            }
        },
        computed: {

        },
        methods: {
      
        },
        mounted() {

        }
    }
</script>

<style>
    .p-footer {
        display: flex;
        justify-content: space-between;
        align-items: center;
        background-color: #545c64;
        color: #fff;
        height: 140px;
    }
    .p-padding {
        padding: 10px;
    }
</style>