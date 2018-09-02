<template>
  <div class="profile-body">
    <!-- left body blocks -->
    <div class="left-body body-column">
      <!-- general block -->
      <div class="general-block body-block">
        <div class="block-header">Профиль</div>
        <div class="block-body">
            <div v-if="profile.PictureUrl" class="block-body-item">
              <div class="avatar">
                <img :src="profile.PictureUrl"/>
              </div>
            </div>
          <div v-else class="block-body-item">
              <div class="avatar">
                <div class="name">
                  {{profile.firstName ? profile.firstName.charAt(0).toUpperCase() : ""}}
                  {{profile.LastName ? profile.LastName.charAt(0).toUpperCase() : ""}}
                </div>
              </div>
            </div>
          <div class="item-row">
            {{profile.firstName}}
          </div>
          <div v-if="profile.LastName" class="block-label item-row">
            {{profile.lastName}}
          </div>
          <div v-if="profile.surname" class="block-label item-row">
            {{profile.surname}}
          </div>
        </div>
        <!-- end general block -->

      </div>
      <!-- end left body blocks -->
    </div>
    <!-- default body blocks -->
    <div class="default-body body-column">
      <!-- default block -->
      <div class="default-block body-block">
        <div class="block-header">Мои контакты</div>
        <div class="default-block-item">
          <div class="item-row">
            <div class="row-label">
              {{profile.email}}
            </div>
            <div class="row-button">Изменить</div>
          </div>
          <div class="item-row">
            <div class="row-label">
              {{profile.phone ? profile.phone : "Номер не добавлен"}}
            </div>
            <div class="row-button">Изменить</div>
          </div>
        </div>
      </div>
       <!--end default block -->
    </div>
    <!-- end default body blocks -->
  </div>
</template>

<script>
import { mapGetters } from "vuex";
import { USER_REQUEST } from "../../store/actions/user";

export default {
  name: "index",
  methods: {},
  computed: {
    ...mapGetters(["profile"])
  }
};
</script>

<style>
</style>
