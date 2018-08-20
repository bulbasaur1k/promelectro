<template>
  <div>
    <div class="left">
        {{profile}}
    </div>
    <div class="center">

    </div>
    <div class="right">

    </div>
  </div>
</template>

<script>
  import {mapGetters} from 'vuex'

  export default {
    name: "index",

    computed:{
      ...mapGetters(['profile'])
    },
  }

</script>

<style scoped>

</style>
