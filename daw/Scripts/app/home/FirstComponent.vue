<template>
  <div class="product-grids col-md-12">
    <template  v-for="(item,index) in Products">
    <div class="col-md-4" style="border: 0.5px solid black; border-color: #cac3c3;">
      <div>
        <a :href="'/Products/Details/' + item.id">
          <img :src="item.image" style="width: 100%; margin-top: 2px; max-height: 150px; max-width: 250px;" alt="" />
        </a>
      </div>
      <div style="height: 50px;">
        <h5 style="text-align: center">
          <a class="name" :href="'/Products/Details/' + item.id">  {{ item.locationName }} </a>
        </h5>
        <p style="float: right">Note: 
          <span class="item_note"> {{ item.note }} </span>
        </p>
        <div class="ofr">
          <a v-on:click="addToWishlist(item.id)" title="Wishlist" v-if="checkUser()">
            <button style="border-radius: 50%; border: none; background-color: #ffaf1b">+</button>
          </a>
         
        </div>
      </div>
      
    </div>
      <div v-if="(index+1) % 3 == 0" class="clearfix"></div>
    </template>
  </div>
</template>
<script>

  import axios from 'axios';
  export default {
  data(){
  return{
  Products: []
  }
  },
  methods: {
  loadData(search = undefined, tip = undefined, note = undefined) {
  axios.get('/api/ApiProduct', {
  params: {search: search,
  tip: tip,
  note: note}
  }).then(response => { console.log(response.data);
  this.Products = response.data;
  })
  },

  checkUser() {
  if(User){ console.log(User);
  if(User.auth == "True") {return true; }
  else {return false;}
  }else{
  return false;
  }
  },

  addToWishlist(id){
  axios.post('/api/ApiProduct', {
  locationId: id,
  }).then(response => {console.log("adaugat") })

  }
  },

  created() {
  Event.$on('search-query', (query) => {
  this.loadData(query.Search, query.Tip, query.Note)
  });

  this.loadData();
  }
  }

</script>
