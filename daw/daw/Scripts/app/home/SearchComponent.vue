<template>
  <div class="col-md-3 rsidebar">
                <div class="rsidebar-top">
                    <div class="sidebar-row">
                        <h4> Filter products </h4>
                            <div class="search-container">
                              <input style="border-radius: 2px" type="text" placeholder="ex. New York" name="search" v-on:keyup="searchByText" v-model="Search"></input>
                            </div>

                      <br>
                        <div >National/International:
                       <select style="margin-top: 10px; border-radius: 2px; width: 178px; height: 30px;" v-model="Note" v-on:change="searchByText">
							         <option name="no filter" value="undefined">None</option>
							         <option name="low" value="0">Up</option>
							         <option name="high" value="1">Down</option>
						            </select>
                            </div>
                        <br>
                            <div > Sort by note: 
                        <select style="margin-top: 10px; border-radius: 2px; width: 178px; height: 30px;" v-model="Tip" v-on:change="searchByText">
							         <option name="both" value="undefined">Both</option>
							         <option name="national" value="true">National</option>
							         <option name="international" value="false">International</option>
						          </select>
                            </div>
                    </div>
                </div>

            </div>
</template>
<script>

  export default {
  data(){
  return{
  Search: undefined,
  Tip: undefined,
  Note: undefined,
  }
  },
  methods: {
  searchByText(event) {
  if (event.keyCode === 13) {
  console.log(this.Search, this.Tip); console.log("asd");
  Event.$emit('search-query', {Search: this.Search, Tip: this.Tip, Note: this.Note});
  }
  }

  },
  watch: {
  Tip: function() {
  Event.$emit('search-query', {Search: this.Search, Tip: this.Tip, Note: this.Note});
  },
  Note: function() {
  Event.$emit('search-query', {Search: this.Search, Tip: this.Tip, Note: this.Note});
  }
  }
  }
</script>
