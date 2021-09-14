<template>
  <div class="content">
    <div class="header-content flex">
      <TitleSalary />
      <div class="box-btn-add">
        <button class="m-btn btn-add">
          <div class="icon-add"></div>
          <div class="text-add">Thêm mới</div>
        </button>
      </div>
    </div>
    <div class="toolbar-content flex relative">
      <div class="box-search relative">
        <input
          type="text"
          class="m-input input-search"
          placeholder="Tìm kiếm"
        />
        <div class="icon-search"></div>
      </div>
      <div class="toolbar-right flex">
          <BaseDropdown style="margin-right:20px"/>
          <BaseDropdownSingle/>
        <div class="box-filter-toolbar">
          <div class="icon-filter-toolbar"></div>
        </div>
        <div class="box-setting-toolbar">
          <div class="icon-setting-toolbar"></div>
        </div>
      </div>
    </div>
    <div class="table-salary">
      <BaseGrid/>
    </div>
  </div>
</template>

<script>
import TitleSalary from "../../components/base/BaseTitle.vue";
import BaseDropdown from "../../components/base/BaseDropdown.vue";
import BaseDropdownSingle from "../../components/base/BaseDropdownSingle.vue";
import BaseGrid from "../../components/base/BaseGrid.vue";
export default {
  name: "SalaryList",
  components: {
    TitleSalary,BaseDropdown,BaseDropdownSingle
    ,BaseGrid
  },
};
</script>

<style>
</style>