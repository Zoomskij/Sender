import Vue from 'vue';

import ElementUI from 'element-ui'
import locale from 'element-ui/lib/locale'
import ruLocale from 'element-ui/lib/locale/lang/ru-RU'

locale.use(ruLocale);
Vue.use(ElementUI, { ruLocale });

import Root from "~/Home/components/Root.vue";

import axios from 'axios';

Vue.prototype.$axios = axios;


Vue.component("root", Root);

function startOnLoad() {

    Vue.config.devtools = true;

    var vv = new Vue({
        el: "#app",
        data: {


        },
        methods: {
            
        }

    });
}

startOnLoad();