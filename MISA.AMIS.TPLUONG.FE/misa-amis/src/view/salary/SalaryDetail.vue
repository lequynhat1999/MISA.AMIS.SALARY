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
      <ValidationObserver ref="form_salary">
        <div class="content-form">
          <div class="content-wrapper">
            <div class="flex">
              <div class="text-input">
                <b>Tên thành phần <span style="color: red">*</span></b>
              </div>
              <ValidationProvider
                rules="validateRequired"
                name="Tên thành phần"
                v-slot="{ errors }"
              >
                <input
                  type="text"
                  v-model="employee.EmployeeCode"
                  class="m-input input-text-form"
                  :class="{
                    'border-red': errors.length > 0 ? true : false,
                  }"
                />
                <div class="text-error">{{ errors[0] }}</div>
              </ValidationProvider>
            </div>
            <div class="input-form flex">
              <div class="text-input">
                <b>Mã thành phần <span style="color: red">*</span></b>
              </div>
              <input
                type="text"
                class="m-input input-text-form"
                placeholder="Nhập mã viết liền"
              />
            </div>
            <div class="input-form flex">
              <div class="text-input">
                <b>Đơn vị áp dụng <span style="color: red">*</span></b>
              </div>
              <DropdownMulti
                style="margin-left: 24px; max-width: 629px"
                :treeDataSource="treeDataSource"
                :placeholderProp="''"
                :valueExprProp="'OrganizationUnitID'"
                :displayExprProp="'OrganizationUnitName'"
                :parentIdExprProp="'ParentID'"
                :valueDefault="treeDataSource[0].OrganizationUnitID"
              />
            </div>
            <div class="input-form flex">
              <div class="text-input">
                <b>Loại thành phần <span style="color: red">*</span></b>
              </div>
              <SelectBox
                style="margin-left: 25px; max-width: 237px"
                :displayExprProp="'TypeName'"
                :valueExprProp="'TypeID'"
                :dataSource="dataSourceType"
                :valueDefault="false"
                :disabledProp="false"
              />
            </div>
            <div class="input-form flex">
              <div class="text-input">
                <b>Tính chất <span style="color: red">*</span></b>
              </div>
              <SelectBox
                style="margin-left: 25px; max-width: 237px"
                :displayExprProp="'NatureName'"
                :valueExprProp="'NatureID'"
                :dataSource="dataSourceNature"
                :valueDefault="dataSourceNature[0].NatureID"
                :disabledProp="false"
                @getValueItem="getValueItem"
              />
              <div class="box-earning" v-if="itemID == 1">
                <div class="earning-wrapper flex a-l-c">
                  <!-- <input
                  type="radio"
                  id="Chịu thuế"
                  name="earning"
                  class="radio-earning"
                  value="1"
                />
                <span class="btn-check"></span>
                <span class="btn-uncheck"></span>
                <label for="Chịu thuế" class="text-radio">Chịu thuế</label>
                <input
                  type="radio"
                  id="Không chịu thuế"
                  name="earning"
                  class="radio-earning"
                  value="2"
                  style="margin-left: 30px"
                />
                <span class="btn-check"></span>
                <span class="btn-uncheck"></span>
                <label for="Không chịu thuế" class="text-radio"
                  >Không chịu thuế</label
                > -->
                  <DxRadioGroup
                    :items="dataTax"
                    :value="dataTax[0]"
                    layout="horizontal"
                  />
                </div>
              </div>
              <div class="box-earning" v-if="itemID == 2">
                <div class="deduct-wrapper flex">
                  <!-- <input
                  type="checkbox"
                  id="deduct"
                  style="width: 16px; height: 16px"
                />
                <label for="deduct" class="text-checkbox"
                  >Giảm trừ khi tính thuế</label
                > -->
                  <DxCheckBox :width="550" text="Giảm trừ khi tính thuế" />
                </div>
              </div>
            </div>
            <div class="input-form flex">
              <div class="text-input flex">
                <b>Định mức</b>
                <div
                  class="icon-quota"
                  title="Khi tính giá trị của thành phần lương này, nếu số tiền vượt quá định mức thì chương trình sẽ tự động lấy mức tối đa theo định mức đã thiết lập"
                ></div>
              </div>
              <input type="text" class="m-input input-text-form" />
            </div>
            <div class="input-form flex">
              <div class="text-input">
                <b>Kiểu giá trị</b>
              </div>
              <SelectBox
                style="margin-left: 25px; max-width: 237px"
                :displayExprProp="'ValueTypeName'"
                :valueExprProp="'ValueTypeID'"
                :dataSource="dataSourceValueType"
                :valueDefault="dataSourceValueType[0].ValueTypeID"
                :disabledProp="true"
              />
            </div>
            <div class="input-form flex">
              <div class="text-input">
                <b>Giá trị</b>
              </div>
              <textarea
                class="m-input input-text-form"
                placeholder="Tự động gợi ý công thức và tham số khi gõ"
                style="height: 71px"
              />
            </div>
            <div class="input-form flex">
              <div class="text-input">
                <b>Mô tả</b>
              </div>
              <textarea class="m-input input-text-form" style="height: 71px" />
            </div>
          </div>
        </div>
      </ValidationObserver>
    </div>
  </div>
</template>

<script>
import SelectBox from "../../components/base/BaseSelectBox.vue";
import DropdownMulti from "../../components/base/BaseDropdownMulti.vue";
import DxRadioGroup from "devextreme-vue/radio-group";
import { extend } from "vee-validate";
import { required } from "vee-validate/dist/rules";
import { DxCheckBox } from "devextreme-vue/check-box";
import {
  TYPE,
  NATURE,
  VALUE_TYPE,
  TREE_DATA_SOURCE,
} from "../../js/common/data.js";
extend("validateRequired", {
  ...required,
  message: "Không được để trống",
});

export default {
  name: "SalaryDetail",
  components: {
    SelectBox,
    DropdownMulti,
    DxCheckBox,
    DxRadioGroup,
  },
  props: ["isOpenModal"],
  data() {
    return {
      employee: { EmployeeCode: "123", Test: "ABC" },
      // dataSource selectbox
      dataSourceType: TYPE,
      dataSourceNature: NATURE,
      dataSourceValueType: VALUE_TYPE,
      // dataSource của dropdown multi
      treeDataSource: TREE_DATA_SOURCE,
      // id của item
      isShowRadio: false,
      // value default cho input tính chất
      itemID: 1,
      // data cho radio
      // dataTax: [
      //   { TaxName: 'Chịu thuế', TaxValue: 1 },
      //   { TaxName: 'Không chịu thuế', TaxValue: 2 },
      // ]
      dataTax: ["Chịu thuế", "Không chịu thuế"],
    };
  },
  methods: {
    /**------------------------------------------------------------------------------
     * Sự kiện click nút <-
     * CreatedBy: LQNHAT(15/09/2021)
     */
    closeFormDetail() {
      // close form
      this.$emit("closeForm");
    },
    /**---------------------------------------------------------
     * Gán id để hiển thị label
     * CreatedBy: LQNHAT(15/09/2021)
     */
    getValueItem(id) {
      this.itemID = id;
      console.log("id item detail : " + this.itemID);
    },
  },
};
</script>

<style>
</style>