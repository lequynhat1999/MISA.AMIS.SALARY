<template>
  <div id="myModal" class="modal" :class="{ 'hidden-modal': isOpenModal }">
    <div class="modal-content">
      <div class="header-form flex">
        <div class="box-icon-back" title="Quay lại" @click="closeFormDetail">
          <div class="icon-back"></div>
        </div>
        <div class="title-form"><span>Thêm thành phần</span></div>
        <div class="box-btn-header flex">
          <div class="btn-cancel-form m-r-8">
            <button class="m-btn-white">
              <div class="text-btn">Hủy bỏ</div>
            </button>
          </div>
          <div class="btn-save-add-form m-r-8">
            <button class="m-btn-white">
              <div class="text-btn">Lưu và thêm</div>
            </button>
          </div>
          <div class="btn-add-form">
            <button class="m-btn m-btn-add">
              <div class="text-btn">Lưu</div>
            </button>
          </div>
        </div>
      </div>
      <div class="content-form">
        <div class="content-wrapper" >
          <div class=" flex a-l-c">
            <div class="text-input">
              <b>Tên thành phần <span style="color: red">*</span></b>
            </div>
            <input type="text" class="m-input input-text-form" />
          </div>
          <div class="input-form flex a-l-c">
            <div class="text-input">
              <b>Mã thành phần <span style="color: red">*</span></b>
            </div>
            <input type="text" class="m-input input-text-form" placeholder="Nhập mã viết liền"/>
          </div>
          <div class="input-form flex a-l-c">
            <div class="text-input">
              <b>Đơn vị áp dụng <span style="color: red">*</span></b>
            </div>
            <input type="text" class="m-input input-text-form" />
          </div>
          <div class="input-form flex a-l-c">
            <div class="text-input">
              <b>Loại thành phần <span style="color: red">*</span></b>
            </div>
            <SelectBox style="margin-left:25px; max-width:237px" />
          </div>
          <div class="input-form flex a-l-c">
            <div class="text-input">
              <b>Tính chất <span style="color: red">*</span></b>
            </div>
            <input type="text" class="m-input input-text-form" />
          </div>
          <div class="input-form flex a-l-c">
            <div class="text-input flex a-l-c">
              <b>Định mức</b>
              <div class="icon-quota" title="Khi tính giá trị của thành phần lương này, nếu số tiền vượt quá định mức thì chương trình sẽ tự động lấy mức tối đa theo định mức đã thiết lập"></div>
            </div>
            <input type="text" class="m-input input-text-form" />
          </div>
          <div class="input-form flex a-l-c">
            <div class="text-input">
              <b>Kiểu giá trị</b>
            </div>
            <input type="text" class="m-input input-text-form" />
          </div>
          <div class="input-form flex a-l-c">
            <div class="text-input">
              <b>Giá trị</b>
            </div>
            <textarea  class="m-input input-text-form" placeholder="Tự động gợi ý công thức và tham số khi gõ" style="height: 71px;" />
          </div>
          <div class="input-form flex a-l-c">
            <div class="text-input">
              <b>Mô tả</b>
            </div>
            <textarea  class="m-input input-text-form" style="height: 71px;"/>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import SelectBox from "../../components/base/BaseSelectBox.vue"
export default {
  name: "SalaryDetail",
  components:{
    SelectBox
  },
  props: ["isOpenModal"],
  data() {
    return {};
  },
  methods: {
    /**------------------------------------------------------------------------------
     * Sự kiện click nút <-
     * CreatedBy: LQNHAT(30/08/2021)
     */
    closeFormDetail() {
      // close form
      this.$emit("closeForm");
    },
  },
};
</script>

<style>
</style>