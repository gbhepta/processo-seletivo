import Vue from 'vue';
import App from './App.vue';

// --- PrimeVue: biblioteca de componentes para UI

import PrimeVue from 'primevue/config';
Vue.use(PrimeVue, { ripple: true });
// estilos
import 'primevue/resources/themes/saga-blue/theme.css'; //theme
import 'primevue/resources/primevue.min.css';           //core css
import 'primeicons/primeicons.css';                     //icons

// -- Axios: framework para chamadas a APIs

import axios from 'axios';
import https from 'https';
// Criando a propriedade global "this.$http" para ser usada pelos componentes para acesso a API's
Vue.prototype.$http = axios.create({
    httpsAgent: new https.Agent({
        // Para desenvolvimto o codigo a seguir desabilita a checagem de certificado em APIs com HTTPS
        rejectUnauthorized: false
    })
});

// --- Configurações da aplicação

Vue.prototype.$urlApi = "https://localhost:7046/api";  // URL da API

// --- Entry point da aplicação

Vue.config.productionTip = true;

new Vue({
    render: h => h(App)
}).$mount('#app');
