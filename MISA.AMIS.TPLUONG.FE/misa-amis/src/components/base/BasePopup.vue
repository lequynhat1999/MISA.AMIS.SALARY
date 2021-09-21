<template>
  <div class="modal-popup">
    <div class="modal-content-popup">
      <div class="header-popup flex a-l-c">
        <div class="text-header-popup">{{ titlePopup }}</div>
        <div class="box-icon-close-popup" @click="closePopup">
          <div class="icon-close-popup"></div>
        </div>
      </div>
      <div class="content-popup flex a-l-c">
        <div>{{ textPopup }}</div>
      </div>
      <div class="footer-popup relative flex a-l-c">
        <div class="box-btn-popup flex a-l-c">
          <div class="btn-cancel-form m-r-8">
            <button class="m-btn-white btn-cancel-popup" @click="closePopup">
              <div class="text-btn">Hủy</div>
            </button>
          </div>
          <div class="box-btn-delete-popup">
            <button class="m-btn btn-delete-popup" @click="deleteRow">
              <div class="text-btn">Xóa</div>
            </button>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  name: "BasePopup",
  props: ["titlePopup", "textPopup"],
  methods: {
    /**-----------------------------------
     * Đóng popup
     * CreatedBy: LQNHAT(21/09/2021)
     */
    closePopup() {
      this.$emit("closePopup");
    },
    deleteRow()
    {
        this.$emit("deleteRow");
    }
  },
};
</script>

<style>
</style>