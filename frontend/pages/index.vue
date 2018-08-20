<template>
  <div class="container-page">
    <div class="generalmenu-body">
      <div class="general-body">
        <ProjectCube></ProjectCube>
      </div>
      <div class="buttons-block">
        <div class="buttons">
          <ButtonBulb v-bind:waittime="300">Портфолио</ButtonBulb>
          <ButtonBulb v-bind:waittime="200">О Нас</ButtonBulb>
          <ButtonBulb v-bind:waittime="400">Виды работ</ButtonBulb>
          <ButtonBulb v-bind:waittime="500">Контакты</ButtonBulb>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
  import ButtonBulb from '../components/items/ButtonBulb'
  import ProjectCube from '../components/items/ProjectCube'
  export default {
    created: function(){
      this.$store.commit('setPageName','Главная')
    },
    components: {ProjectCube, ButtonBulb}
  }
</script>

<style scoped>

  .container-page {
    height: 100%;
    margin-top: 5rem;
  }

  .buttons {
    width: 100%;
    display: flex;
    flex-direction: column;
    justify-content: space-around;
    /* align-items: center; */
    align-items: center;
    height: 30rem;
  }

  .generalmenu-body {
    display: -webkit-box;
    display: -ms-flexbox;
    display: flex;
    flex-direction: row;
    flex-wrap: nowrap;
    height: 100%;
  }


  .general-body {
    display: flex;
    width: 50%;
  }

  .buttons-block {
    display: -webkit-box;
    display: -ms-flexbox;
    display: flex;
    width: 50%;
    flex-wrap: wrap;
    -ms-flex-line-pack: center;
    align-content: center;
    -webkit-box-pack: center;
    -ms-flex-pack: center;
    justify-content: center;
  }


</style>

