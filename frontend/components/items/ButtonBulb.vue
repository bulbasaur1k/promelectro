<template>
  <delay :wait="waittime">
    <transition
      appear
      appear-active-class="animated bounceInRight"
      leave-active-class="animated bounceOutRight">
      <div class="button-container">
        <div class="button button-glow button-rounded button-highlight">
          <slot></slot>
        </div>
      </div>
    </transition>
  </delay>
</template>

<script>
  export default {
    name: "ButtonBulb",
    data: function () {
      return {
        show: true
      }
    },
    props: {
      waittime: Number
    }
  }
</script>

<style>


  .button {
    width: 13em;
    height: 3em;
    font-size: 1.5em;
    justify-content: center;
    align-items: center;
    display: flex;
    cursor: pointer;
  }

  .button-glow {
    -webkit-animation-duration: 3s;
    animation-duration: 3s;
    -webkit-animation-iteration-count: infinite;
    animation-iteration-count: infinite;
    -webkit-animation-name: glowing;
    animation-name: glowing;
  }

  .button-highlight,
  .button-highlight-flat {
    background-color: white;
    border-color: #57a8d1;
    color: #57a8d1;
    border-width: 2px;
    border-style: solid;
  }

  .button-highlight:visited,
  .button-highlight-flat:visited {
    color: #FFF;
  }

  .button-highlight:hover, .button-highlight:focus,
  .button-highlight-flat:hover,
  .button-highlight-flat:focus {
    background-color: #57a8d1;
    border-color: #57a8d1;
    color: #FFF;
  }

  .button-highlight:active, .button-highlight.active, .button-highlight.is-active,
  .button-highlight-flat:active,
  .button-highlight-flat.active,
  .button-highlight-flat.is-active {
    background-color: #adcbd1;
    border-color: #adcbd1;
  }

  .button-rounded {
    border-radius: 4px;
  }

  .button-glow.button-highlight {
    -webkit-animation-name: glowing-highlight;
    animation-name: glowing-highlight;
  }

  .button-glow:active, .button-glow.active, .button-glow.is-active {
    -webkit-animation-name: none;
    animation-name: none;
  }
</style>
