import Vue from 'vue'
import FirstComponent from './FirstComponent.vue'
import SearchComponent from './SearchComponent.vue'
import {SweetModal, SweetModalTab} from 'sweet-modal-vue'

window.Event = new Vue();

new Vue({
    el: '#app',
    components: {
        'listing': FirstComponent,
        'search' : SearchComponent
    },
    data(){
        return {
            vueMessage: 'Message from Vue'
        }
    }
})