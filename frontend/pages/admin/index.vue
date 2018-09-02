<template>
  <div class="profile-body">
    
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
