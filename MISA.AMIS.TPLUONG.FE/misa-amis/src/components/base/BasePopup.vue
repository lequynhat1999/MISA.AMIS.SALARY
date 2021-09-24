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
        <div class="box-btn-popup flex a-l-c" >
          <div class="btn-cancel-form m-r-8" v-if="statusPopup == 0 || statusPopup == 3 || statusPopup == 4">
            <button class="m-btn-white btn-cancel-popup" @click="closePopup">
              <div class="text-btn">Hủy</div>
            </button>
          </div>
          <div class="box-btn-delete-popup" v-if="statusPopup == 0">
            <button class="m-btn btn-delete-popup" @click="deleteRow">
              <div class="text-btn">Xóa</div>
            </button>
          </div>
          <div class="box-btn-delete-popup" v-if="statusPopup == 3">
            <button class="m-btn btn-delete-popup" @click="deleteMultiRow">
              <div class="text-btn">Xóa</div>
            </button>
          </div>
          <div class="btn-cancel-form m-r-8" v-if="statusPopup == 4">
            <button class="m-btn-white" @click="cancelSave">
              <div class="text-btn">Không lưu</div>
            </button>
          </div>
          <div class="btn-add-form" v-if="statusPopup == 4">
            <button class="m-btn m-btn-add" @click="saveBtnClickPopup">
              <div class="text-btn">Lưu</div>
            </button>
          </div>
        </div>
        <div class="box-btn-popup flex a-l-c">
          <div class="btn-cancel-form m-r-8" @click="closePopup" v-if="statusPopup == 1 || statusPopup == 2 || statusPopup == 5 || statusPopup == 6">
            <button class="m-btn-white">
              <div class="text-btn">Hủy bỏ</div>
            </button>
          </div>
          <div class="btn-add-form" @click="unfollowRow" v-if="statusPopup == 1">
            <button class="m-btn m-btn-add btn-confirm-unfollow">
              <div class="text-btn">Đồng ý</div>
            </button>
          </div>
          <div class="btn-add-form" @click="unfollowMultiRow" v-if="statusPopup == 2">
            <button class="m-btn m-btn-add btn-confirm-unfollow">
              <div class="text-btn">Đồng ý</div>
            </button>
          </div>
          <div class="btn-add-form" @click="followRow" v-if="statusPopup == 5">
            <button class="m-btn m-btn-add btn-confirm-unfollow">
              <div class="text-btn">Đồng ý</div>
            </button>
          </div>
          <div class="btn-add-form" @click="followMultiRow" v-if="statusPopup == 6">
            <button class="m-btn m-btn-add btn-confirm-unfollow">
              <div class="text-btn">Đồng ý</div>
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
  // props: ["titlePopup", "textPopup", "statusPopup"],
  props:{
    titlePopup: {
      type: String,
    },
    textPopup: {
      type: String
    },
    statusPopup: {
      type: Number
    }
  },
  methods: {
    /**-----------------------------------
     * Đóng popup
     * CreatedBy: LQNHAT(21/09/2021)
     */
    closePopup() {
      this.$emit("closePopup");
    },

    /**----------------------------------
     * Xóa dòng
     * CreatedBy: LQNHAT(22/09/2021)
     */
    deleteRow() {
      this.$emit("deleteRow");
    },

    /**-----------------------------------
     * Unfollow
     * CreatedBy: LQNHAT(22/09/2021)
     */
    unfollowRow()
    {
      this.$emit("unfollowRow");
    },

    /**--------------------------------
     * Follow
     * CreatedBy: LQNHAT(24/09/2021)
     */
    followRow()
    {
      this.$emit("followRow");
    },

    /**---------------------------------
     * Unfollow multi
     * CreatedBy: LQNHAT(22/09/2021)
     */
    unfollowMultiRow()
    {
      this.$emit("unfollowMultiRow");
    },

    /**-----------------------------------
     * Follow multi
     * Createdby: LQNHAT(24/09/2021)
     */
    followMultiRow()
    {
      this.$emit("followMultiRow");
    },

    /**--------------------------------
     * Delete multi
     * CreatedBy: LQNHAT(22/09/2021)
     */
    deleteMultiRow()
    {
      this.$emit("deleteMultiRow");
    },

    /**-----------------------------------
     * Bắt sự kiện không lưu
     * CreatedBy: LQNHAT(23/09/2021)
     */
    cancelSave()
    {
      this.$emit("closeForm");
      this.$emit("closePopup");
    },

    /**-------------------------------------
     * Bắt sự kiện nút lưu
     * Createdby: LQNHAT(23/09/2021)
     */
    saveBtnClickPopup()
    {
      this.$emit("closePopup");
      this.$emit("saveBtnClick");
    },
  },
};
</script>

<style>
</style>