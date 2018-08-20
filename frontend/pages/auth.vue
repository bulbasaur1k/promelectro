<template>
  <div class="form-body-container">
    <transition name="fade" mode="out-in">
      <div v-if="!isReg" class="form-body">
        <div v-if="!isValid" style="color:darkred;">Неверно заполнены обязательные поля</div>
        <span>{{ errors.first('Логин') }}</span>
        <input placeholder="Логин" v-validate="'required'" name="Логин" type="text" v-model.trim="loginForm.UserName"/>
        <span>{{ errors.first('пароль') }}</span>
        <input name="Пароль" v-validate="'required'" placeholder="Пароль" type="password" v-model.trim="loginForm.password"/>
        <input v-on:click="SubmitLogin()" class="button button-glow button-highlight" value="Войти" type="button"/>
        <input v-on:click="ToggleForm()" class="button button-glow button-highlight" value="Зарегистрироваться" type="button"/>
      </div>
      <div v-else class="form-body">
        <div v-if="!isValid" style="color:darkred;">Неверно заполнены обязательные поля</div>
        <span>{{ errors.first('email') }}</span>
        <input name="email" v-validate="'required|email'" placeholder="Email" type="email" v-model.trim="regForm.email"/>
        <span>{{ errors.first('Логин') }}</span>
        <input placeholder="Логин" v-validate="'required'" name="Логин" type="text" v-model.trim="regForm.UserName"/>
        <span>{{ errors.first('пароль') }}</span>
        <input name="пароль" v-validate="'confirmed:confirmPassword|min:6|required'" placeholder="Пароль" type="password" v-model.trim="regForm.password"/>
        <input placeholder="Повторите пароль" ref="confirmPassword" name="confirmPassword" v-model.trim="regForm.confirmPassword" type="password"/>
        <span>{{ errors.first('имя') }}</span>
        <input type="text" placeholder="Имя" v-validate="'required'" name="имя" v-model.trim="fregForm.irsName"/>
        <input type="text" placeholder="Фамилия (необязательно)" v-model.trim="regForm.lastName"/>
        <input class="button button-glow button-highlight" value="Зарегистрироваться" v-on:click="SubmitReg()" type="button"/>
        <input v-on:click="ToggleForm()" class="button button-glow button-highlight" value="Я уже зарегистрирован" type="button"/>
      </div>
    </transition>
  </div>
</template>

<script>
  import axios from 'axios'
  import {AUTH_REQUEST} from '../store/actions/auth'
  import {}

  export default {
    name: "auth",
    ransition: 'bounce',e


    data() {
      return {
        isReg: false,
        regForm: {
          email: '',
          userName: '',
          password: '',
          confirmPassword: '',
          firsName: '',
          lastName: '',
        },
        loginForm: {
          userName: '',
          password: '',
        },
        isValid: true,
      }
    },

    head() {
      return {
        title: 'Авторизация'
      }
    },
    methods: {
      ToggleForm() {
        this.isReg = !this.isReg
      },
      SubmitLogin() {
        if (!this.errors.any()) {
          const loginData = this.loginForm;
          this.$store.dispatch(AUTH_REQUEST, loginData).then(() => {
            this.$router.push('/')
          })

        }
        else {
          this.isValid = false
        }
      },
      SubmitReg() {
        if (!this.errors.any()) {
          const regData = this.RegForm;
          this.$store.dispath()
          /*axios.post('http://localhost:5000/api/accounts', this.regForm)
            .then(function (response) {
              if (response.status === 200) {
                window.location = 'http://localhost:3000'
              }
            })
            .catch(function (error) {
              alert('Ошибка на сервре, было отправленно оповщение разработчику');
            });*/
        }
        else {
          this.isValid = false
        }


      }
    }
  }
</script>

