<template>
  <div class="base-loading" :class="{ loading: isLoading }">
    <img
      src="../../assets/img/loading.svg"
      :class="{ 'hidden-img': !isLoading }"
    />
  </div>
</template>

<script>
export default {
  name: "BaseLoading",
  props: ["isLoading"],
};
</script>

<style>
</style>