<template>
  <div id="app">
    <div class="container-body">
      <Header/>
      <div class="page">
        <nuxt/>
      </div>
    </div>
    <Footer/>
  </div>
</template>
<script>
import Header from "../components/Header";
import Footer from "../components/Footer";
import axios from "axios";
import "animate.css";
import "../assets/form.css";
import "../assets/block-theme/style.css";
import { USER_REQUEST } from "../store/actions/user";

export default {
  name: "default",
  components: { Footer, Header },
  created() {
    if (process.browser) {
      const token = localStorage.getItem("user-token");
      if (token) {
        axios.defaults.headers.common = {
          Authorization: `Bearer ${token}`
        };
      }
      let userName = this.$store.getters.profile.UserName;
      console.log(userName);
      if (userName == null || userName === undefined || userName === "") {
        this.$store.dispatch(USER_REQUEST);
      }
    }
  }
};
</script>
<style>
body {
  margin: 0 0.4em;
  background-color: #d6d6d6;
}

html {
  height: 90%;
}

.page {
  min-height: 80vh;
}

.container-body {
  border-bottom-left-radius: 4px;
  border-bottom-right-radius: 4px;
  border-bottom: 1px;
  border-bottom-color: gray;
  margin-bottom: 0.4em;
  -webkit-box-shadow: 0 14px 28px rgba(0, 0, 0, 0.25),
    0 10px 10px rgba(0, 0, 0, 0.22);
  box-shadow: 0 14px 28px rgba(0, 0, 0, 0.25), 0 10px 10px rgba(0, 0, 0, 0.22);
  background-color: white;
  height: 100%;
  min-height: 90vh;
}

#app {
  font-family: "Avenir", Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  color: #2c3e50;
  height: 100%;
}

#footer {
  flex: 1;
  padding: 1rem;
  /*      background: #adcbd1;*/
  letter-spacing: 3px;
  text-align: center;
  text-transform: uppercase;
  height: 6%;
}
</style>

