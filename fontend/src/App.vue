<template>
  <div class="app">
    <router-view></router-view>
  </div>
</template>

<script>
export default {
  name: 'App',
  created(){
    var token = this.$store.getters.token;
    if(localStorage.getItem('token') != null && localStorage.getItem('token') != "undefined"){
      token = localStorage.getItem('token');
      this.$store.dispatch('common/setToken', token);
    }
    if(token == null || token == "undefined"){
      this.$router.push("/login");
    }
  }
}
</script>

<style lang="scss">
body{
  margin: 0px;
}
.app{
  padding: 0px;
  position: absolute;
  top: 0;
  left: 0;
  bottom: 0;
  right: 0;
  background-color: #f5f5f5;
}
</style>
