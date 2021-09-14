<template>
  <div class="content">
    <div class="header-content flex">
      <TitleSalary />
      <div class="box-btn-add">
        <button class="m-btn btn-add" @click="openModal">
          <div class="icon-add"></div>
          <div class="text-btn">Thêm mới</div>
        </button>
      </div>
    </div>
    <div class="toolbar-content flex relative">
      <!-- <div class="box-search relative">
        <input
          type="text"
          class="m-input input-search"
          placeholder="Tìm kiếm"
        />
        <div class="icon-search"></div>
      </div> -->
      <div class="toolbar-right flex">
        <BaseDropdown style="margin-right: 20px" />
        <BaseDropdownSingle style="margin-right: 20px" />
        <div class="box-filter-toolbar">
          <div class="icon-filter-toolbar"></div>
        </div>
        <div class="box-setting-toolbar">
          <div class="icon-setting-toolbar"></div>
        </div>
      </div>
    </div>
    <div class="table-salary">
      <BaseGrid />
      <div class="amount">Tổng số bản ghi: <b>175</b></div>
    </div>
    <SalaryDetail 
      :isOpenModal="isOpenModal"
      @closeForm="closeForm"
    />
  </div>
</template>

<script>
import TitleSalary from "../../components/base/BaseTitle.vue";
import BaseDropdown from "../../components/base/BaseDropdown.vue";
import BaseDropdownSingle from "../../components/base/BaseDropdownSingle.vue";
import BaseGrid from "../../components/base/BaseGrid.vue";
import SalaryDetail from "../salary/SalaryDetail.vue";
export default {
  name: "SalaryList",
  components: {
    TitleSalary,
    BaseDropdown,
    BaseDropdownSingle,
    BaseGrid,
    SalaryDetail,
  },
  data() {
    return {
      // mở modal
      isOpenModal: true,
    }
  },
  methods: {
    /**------------------------------------------------
     * Bắt sự kiện mở form chi tiết
     * CreatedBy: LQNHAT(14/09/2021)
     */
    openModal() {
      this.isOpenModal = !this.isOpenModal;
    },

    /**---------------------------------------------------------
     * Bắt sự kiện đóng form chi tiết
     * CreatedBy : LQNHAT(14/09/2021)
     */
    closeForm() {
      this.isOpenModal = true;
    },
  },
};
</script>

<style>
</style>