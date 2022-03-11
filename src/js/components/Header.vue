<template>
    <div>
        <el-menu :default-active="activeIndex2"
                 class="el-menu-demo"
                 mode="horizontal"
                 @select="handleSelect"
                 background-color="#545c64"
                 text-color="#fff"
                 active-text-color="#ffd04b">
            <el-menu-item index="1"><router-link to="/">Home</router-link></el-menu-item>
            <el-submenu index="2">
                <template slot="title">
                    Workspace
                </template>
                <el-menu-item index="2-1">item one</el-menu-item>
                <el-menu-item index="2-2">item two</el-menu-item>
                <el-menu-item index="2-3">item three</el-menu-item>
                <el-submenu index="2-4">
                    <template slot="title">
                        item four
                    </template>
                    <el-menu-item index="2-4-1">item one</el-menu-item>
                    <el-menu-item index="2-4-2">item two</el-menu-item>
                    <el-menu-item index="2-4-3">item three</el-menu-item>
                </el-submenu>
            </el-submenu>
            <el-menu-item index="3"><router-link to="/reviews">Reviews</router-link></el-menu-item>

            <el-menu-item index="4"><router-link to="/orders">Orders</router-link></el-menu-item>

            <el-menu-item index="5"><p-login></p-login></el-menu-item>

            <el-menu-item index="6"><p-registration></p-registration></el-menu-item>
        </el-menu>
    </div>
</template>

<script>
    export default {
        name: 'print-layer-header',
        components: {
        },
        data() {
            return {
                activeIndex: '1',
                activeIndex2: '1'
            }
        },
        computed: {

        },
        methods: {
            handleSelect(key, keyPath) {
                console.log(key, keyPath);
            }
        },
        mounted() {

        }
    }
</script>