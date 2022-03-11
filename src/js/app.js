import Vue from 'vue'
import VueRouter from 'vue-router'

import ElementUI from 'element-ui'
import locale from 'element-ui/lib/locale'
import ruLocale from 'element-ui/lib/locale/lang/ru-RU'
import axios from 'axios';
import Header from "~/components/Header.vue";
import Footer from "~/components/Footer.vue";

import Home from "~/Home/components/Root.vue";
import Review from "~/Reviews/components/Root.vue";
import Order from "~/Orders/components/Root.vue";
import News from "~/Home/components/News.vue";
import LoginVue from '~/components/Login.vue';
import Upload from '~/components/Upload.vue';

import RegistrationVue from '~/components/Registration.vue'

Vue.use(VueRouter);
locale.use(ruLocale);
Vue.use(ElementUI, { ruLocale });
Vue.prototype.$axios = axios;

Vue.component("print-layer-header", Header);
Vue.component("print-layer-footer", Footer);
Vue.component("news", News);
Vue.component("p-login", LoginVue);
Vue.component("p-upload", Upload);
Vue.component("p-registration", RegistrationVue);

function startOnLoad() {


    var router = new VueRouter({
        routes: [
            { path: '/', caseSensitive: false, component: Home },
            { path: '/reviews', caseSensitive: false, component: Review },
            { path: '/orders', caseSensitive: false, component: Order }
        ]
    });
    Vue.config.devtools = true;

    var vv = new Vue({
        el: "#vue-router",
        router,
        data: {

        },
        methods: {
            back() {
                this.$router.go(-1);
            },

            // ROUTING ------------------------------------------
            isCurrentRoute(name) {
                return this.$route.name === name;
            },
        },


    });

    var app = new Vue({
        el: '#app',
        router,
        data: {

        },
        methods: {

        }
    });
}

startOnLoad();