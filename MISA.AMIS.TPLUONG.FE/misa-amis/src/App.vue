<template>
  <div id="app">
    <Menu />
    <Content />
  </div>
</template>

<script>
import Menu from "../src/components/layout/TheMenu.vue";
import Content from "../src/components/layout/TheContent.vue";
export default {
  name: "App",
  components: {
    Menu,
    Content,
  },
};
</script>

<style>
@import "./css/page/menu.css";
@import "./css/base/flex.css";
@import "./css/base/font-size.css";
@import "./css/page/content.css";
@import "./css/salary/list.css";
@import "./css/base/title.css";
@import "./css/base/button.css";
@import "./css/base/input.css";
@import "./css/base/relative.css";
* {
  margin: 0;
  padding: 0;
  box-sizing: border-box;
  outline: none;
  text-transform: none;
  text-decoration: none;
}

body {
  font-family: Roboto, Helvetica, Arial, sans-serif;
  font-size: 14px;
  background: #f4f5f8;
  color: #111;
  overflow: hidden;
}

::-webkit-scrollbar-track {
  background: #fff;
}

::-webkit-scrollbar-thumb {
  background: #888;
}

::-webkit-scrollbar-thumb:hover {
  background: #555;
}

::-webkit-scrollbar {
  height: 4px;
  width: 4px;
  border: 1px solid #888;
}
</style>
