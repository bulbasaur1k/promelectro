<template>
  <div>
    <div id="header">

      <div class="logo">
        <nuxt-link to="/">
        <img src="../assets/img/logo/promelectro.svg"/>
        </nuxt-link>
      </div>

      <div class="bar-menu">
        <div class="menu" v-on:click="isBarStart = !isBarStart">
          <div class="bar down" v-bind:class="{downstart : isBarStart}"></div>
          <div class="bar fade" v-bind:class="{fadestart : isBarStart}"></div>
          <div class="bar up" v-bind:class="{upstart : isBarStart}"></div>
        </div>
        <div>Меню</div>
      </div>
      <div class="description">
        {{this.$store.state.pageName}}
      </div>
    </div>
    <div class="nav-menu" v-bind:class="{menushow : isBarStart}">
      <div>
        <ul class="nav-menu-pages">
          <li>
            <a >
              Главная
            </a>
          </li>
          <li>
            <a >
              О нас
            </a>
          </li>
          <li>
            <a >
              Виды работ
            </a>
          </li>
          <li>
            <a >
              Котнтакты
            </a>
          </li>
        </ul>
      </div>
    </div>
  </div>
</template>

<script>
  export default {
    name: "Header",
    data() {
      return {
        isBarStart: false,
        title: 'Главная'
      }
    }



  }
</script>

<style scoped>
  img {
    height: 4em;
  }

  .nav-menu-pages {
    display: -webkit-box;
    display: -ms-flexbox;
    display: flex;
    -webkit-box-orient: vertical;
    -webkit-box-direction: normal;
    -ms-flex-direction: column;
    flex-direction: column;
    -ms-flex-wrap: wrap;
    flex-wrap: wrap;
    list-style: none;
  }
  .nav-menu-pages li {
    margin: 9px 0 0;
    text-align: center;
    list-style: none;
  }

  .nav-menu-pages li a {
    display: inline-block;
    font-weight: 700;
    line-height: 2.08;
    letter-spacing: .9px;
    font-size: 1.25em;
    cursor: pointer;
  }

  .nav-menu {
    background: #fff;
    height: 100vh;
    -webkit-transform: translateY(-200vh);
    transform: translateY(-200vh);
    -webkit-transition: all .4s ease-in-out;
    transition: all .4s ease-in-out;
    /* position: absolute; */
    top: 0;
    left: 0;
    right: 0;
    display: -webkit-box;
    display: -ms-flexbox;
    display: flex;
    -webkit-box-pack: center;
    -ms-flex-pack: center;
    justify-content: center;
    -webkit-box-align: center;
    -ms-flex-align: center;
    align-items: center;
    width: 80vm;
    position: absolute;
    z-index: 100;
    margin: 0 .4em;
  }

  .menushow {
    -webkit-transform: none;
    -ms-transform: none;
    transform: none;
  }

  .description {
    width: 14em;
    display: flex;
    align-items: center;
    justify-content: center;
  }

  .bar-menu {
    display: -webkit-box;
    display: -ms-flexbox;
    display: flex;
    -webkit-box-pack: center;
    -ms-flex-pack: center;
    justify-content: space-between;
    width: 5em;
    align-items: center;
  }

  #header {
    display: flex;
    flex-direction: row;
    flex-flow: row;
    justify-content: space-around;
    height: 5em;
    width: 100%;
    z-index: 200;
    position: relative;
  }

  .menu {
    width: 25px;
    cursor: pointer;
    z-index: 5;
  }

  .logo {
    display: -webkit-box;
    display: -ms-flexbox;
    display: flex;
    -webkit-box-pack: start;
    -ms-flex-pack: start;
    justify-content: space-around;
    width: 17em;
    align-content: center;
    align-items: center;
    cursor: pointer;
  }

  .bar {
    height: 4px;
    width: 25px;
    border-radius: 2px;
    background-color: #000;
    display: flex;
    justify-self: center;
    justify-content: center;
    margin-bottom: 5px;
    transition: transform 1s linear;
    -webkit-transform-origin: 0;
  }

  .down {
    -webkit-transform: translateY(0) rotate(0deg);
    transform: translateY(0) rotate(0deg);
    -webkit-animation: downrev 0.9s ease forwards;
    animation: downrev 0.9s ease forwards;
  }

  .downstart {
    -webkit-animation: down 0.7s ease forwards;
    animation: down 0.7s ease forwards;
  }

  @-webkit-keyframes down {
    0% {
      -webkit-transform: translateY(0)
    }
    55% {
      -webkit-transform: translateY(9px)
    }
    65% {
      -webkit-transform: translateY(9px)
    }
    100% {
      -webkit-transform: rotate(45deg)
    }
  }

  @-webkit-keyframes downrev {
    0% {
      -webkit-transform: rotate(45deg)
    }
    35% {
      -webkit-transform: rotate(0deg)
    }
    45% {
      -webkit-transform: translateY(0px)
    }
    100% {
      -webkit-transform: translateY(0px)
    }
  }

  .fade {
    -webkit-animation: faderev 0.9s ease forwards;
    animation: faderev 0.9s ease forwards;
  }

  .fadestart {
    -webkit-animation: fade 0.7s ease forwards;
    animation: fade 0.7s ease forwards;
  }

  @-webkit-keyframes fade {
    0% {
      opacity: 1;
    }
    55% {
      opacity: 1;
    }
    60% {
      opacity: 0;
    }
    100% {
      opacity: 0;
    }
  }

  @-webkit-keyframes faderev {
    0% {
      opacity: 0
    }
    75% {
      opacity: 1
    }
    100% {
      opacity: 1
    }
  }

  .up {
    -webkit-transform: translateY(0) rotate(0deg);
    transform: translateY(0) rotate(0deg);
    -webkit-animation: uprev 0.9s ease forwards;
    animation: uprev 0.9s ease forwards;
  }

  .upstart {
    -webkit-animation: up 0.7s ease forwards;
    animation: up 0.7s ease forwards;
  }

  @-webkit-keyframes up {
    0% {
      -webkit-transform: translateY(0)
    }
    55% {
      -webkit-transform: translateY(-9px)
    }
    65% {
      -webkit-transform: translateY(-9px)
    }
    100% {
      -webkit-transform: rotate(-45deg)
    }
  }

  @-webkit-keyframes uprev {
    0% {
      -webkit-transform: rotate(-45deg)
    }
    35% {
      -webkit-transform: rotate(0deg)
    }
    45% {
      -webkit-transform: translateY(0px)
    }
    100% {
      -webkit-transform: translateY(0px)
    }
  }
</style>
