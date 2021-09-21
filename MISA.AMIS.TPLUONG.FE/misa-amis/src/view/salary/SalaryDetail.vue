<template>
  <div id="myModal" class="modal" :class="{ 'hidden-modal': isOpenModal }">
    <div class="modal-content">
      <div class="header-form flex">
        <div class="box-icon-back" title="Quay lại" @click="closeFormDetail">
          <div class="icon-back"></div>
        </div>
        <div class="title-form" v-if="mode == 0">
          <span>Thêm thành phần</span>
        </div>
        <div class="title-form" v-else>
          <span>{{ salaryComposition.SalaryCompositionName }}</span>
        </div>
        <div class="box-btn-header flex" v-if="mode == 0">
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
          <div class="btn-add-form" @click="saveBtnClick">
            <button class="m-btn m-btn-add">
              <div class="text-btn">Lưu</div>
            </button>
          </div>
        </div>
        <div class="box-btn-header flex" v-else>
          <div class="btn-add-form" @click="openBoxBtn" v-if="hiddenBoxBtn">
            <button class="m-btn m-btn-add btn-edit-detail">
              <div class="text-btn">Sửa</div>
            </button>
          </div>
          <div class="box-btn-detail flex" v-else>
            <div class="btn-cancel-form m-r-8" @click="closeBoxBtn">
              <button class="m-btn-white">
                <div class="text-btn">Hủy bỏ</div>
              </button>
            </div>
            <div class="btn-add-form">
              <button class="m-btn m-btn-add btn-edit-detail">
                <div class="text-btn">Lưu</div>
              </button>
            </div>
          </div>

          <div
            class="box-context-menu"
            @click="toggleContextMenu"
            :class="{ 'box-content-active': !hiddenContextMenu }"
          >
            <div class="icon-context"></div>
            <div class="context-menu-data" v-if="!hiddenContextMenu">
              <div class="box-item-context">
                <div class="item-context flex a-l-c">
                  <div class="icon-item-context"></div>
                  <div class="text-item-context">Nhân bản</div>
                </div>
                <div class="item-context flex a-l-c">
                  <div class="icon-item-context icon-context-delete"></div>
                  <div class="text-item-context text-context-delete">Xóa</div>
                </div>
              </div>
            </div>
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
              <ValidationProvider rules="validateRequired" v-slot="{ errors }">
                <input
                  type="text"
                  ref="salaryCompositionName"
                  v-model="salaryComposition.SalaryCompositionName"
                  class="m-input input-text-form"
                  :class="{
                    'border-red': errors.length > 0 ? true : false,
                  }"
                />
                <div v-if="errors.length > 0">
                  <div class="text-error">{{ errors[0] }}</div>
                </div>
              </ValidationProvider>
            </div>
            <div class="input-form flex">
              <div class="text-input">
                <b>Mã thành phần <span style="color: red">*</span></b>
              </div>
              <ValidationProvider rules="validateRequired" v-slot="{ errors }">
                <input
                  type="text"
                  v-model="salaryComposition.SalaryCompositionCode"
                  class="m-input input-text-form"
                  placeholder="Nhập mã viết liền"
                  :class="{
                    'border-red': errors.length > 0 ? true : false,
                  }"
                  @blur="checkDuplicateCode"
                />
                <div v-if="errors.length > 0">
                  <div class="text-error">{{ errors[0] }}</div>
                </div>
              </ValidationProvider>
            </div>
            <div class="input-form flex">
              <div class="text-input">
                <b>Đơn vị áp dụng <span style="color: red">*</span></b>
              </div>
              <ValidationProvider rules="validateRequired" v-slot="{ errors }">
                <DropdownMulti
                  style="margin-left: 24px; width: 629px"
                  :treeDataSource="treeDataSource"
                  :placeholderProp="''"
                  :valueExprProp="'OrganizationUnitID'"
                  :displayExprProp="'OrganizationUnitName'"
                  :parentIdExprProp="'ParentID'"
                  :valueDefault="
                    treeDataSource.length > 0
                      ? treeDataSource[6].OrganizationUnitID
                      : 'c0ff752c-5ff4-4238-998b-4235c9818b00'
                  "
                  v-model="salaryComposition.OrganizationUnitID"
                  :class="{
                    'border-red-component': errors.length > 0 ? true : false,
                  }"
                />
                <div v-if="errors.length > 0">
                  <div class="text-error">{{ errors[0] }}</div>
                </div>
              </ValidationProvider>
            </div>
            <div class="input-form flex">
              <div class="text-input">
                <b>Loại thành phần <span style="color: red">*</span></b>
              </div>
              <ValidationProvider rules="validateRequired" v-slot="{ errors }">
                <SelectBox
                  style="margin-left: 25px; width: 237px"
                  :dataSource="dataSourceType"
                  :valueExprProp="'SalaryCompositionTypeID'"
                  :displayExprProp="'SalaryCompositionTypeName'"
                  :valueDefault="false"
                  :disabledProp="false"
                  v-model="salaryComposition.SalaryCompositionTypeID"
                  :class="{
                    'border-red-component': errors.length > 0 ? true : false,
                  }"
                />
                <div v-if="errors.length > 0">
                  <div class="text-error">{{ errors[0] }}</div>
                </div>
              </ValidationProvider>
            </div>
            <div class="input-form flex">
              <div class="text-input">
                <b>Tính chất <span style="color: red">*</span></b>
              </div>
              <ValidationProvider rules="validateRequired" v-slot="{ errors }">
                <SelectBox
                  style="margin-left: 25px; width: 237px"
                  :displayExprProp="'NatureName'"
                  :valueExprProp="'NatureID'"
                  :dataSource="dataSourceNature"
                  :valueDefault="dataSourceNature[0].NatureID"
                  :disabledProp="false"
                  v-model="salaryComposition.NatureID"
                  :class="{
                    'border-red-component': errors.length > 0 ? true : false,
                  }"
                />
                <div v-if="errors.length > 0">
                  <div class="text-error">{{ errors[0] }}</div>
                </div>
              </ValidationProvider>
              <div class="box-earning" v-if="salaryComposition.NatureID == 1">
                <div class="earning-wrapper flex a-l-c">
                  <DxRadioGroup
                    :dataSource="dataSourceTax"
                    :display-expr="'TaxableName'"
                    :value-expr="'TaxableID'"
                    :value="dataSourceTax[0].TaxableID"
                    layout="horizontal"
                    v-model="salaryComposition.TaxableID"
                  />
                </div>
              </div>
              <div class="box-earning" v-if="salaryComposition.NatureID == 2">
                <div class="deduct-wrapper flex">
                  <DxCheckBox
                    :width="550"
                    text="Giảm trừ khi tính thuế"
                    :value="false"
                    v-model="salaryComposition.ReduceBoolean"
                  />
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
              <money
                type="text"
                class="m-input input-text-form"
                style="text-align: right"
                value=""
                v-bind="money"
                v-model="salaryComposition.Quota"
              ></money>
              <!-- <vue-autonumeric :options="'integer'" v-model="salaryComposition.Quota"></vue-autonumeric> -->
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
                v-model="salaryComposition.Cost"
              />
            </div>
            <div class="input-form flex">
              <div class="text-input">
                <b>Mô tả</b>
              </div>
              <textarea
                class="m-input input-text-form"
                style="height: 71px"
                v-model="salaryComposition.Description"
              />
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
import { Money } from "v-money";
import axios from "axios";
import { NATURE, VALUE_TYPE, URL_API } from "../../js/common/data.js";
// import VueAutonumeric from '../src/components/VueAutonumeric.vue';
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
    Money,
    // VueAutonumeric,
  },
  props: ["isOpenModal", "treeDataSource"],
  data() {
    return {
      // v-money
      money: {
        decimal: ",",
        thousands: ",",
        precision: 0,
        masked: false,
      },
      // dataSource selectbox
      dataSourceType: [],
      dataSourceNature: NATURE,
      dataSourceValueType: VALUE_TYPE,
      // id của item
      isShowRadio: false,
      // value default cho input tính chất
      itemID: 1,
      // data cho radio
      dataSourceTax: [
        { TaxableName: "Chịu thuế", TaxableID: 0 },
        { TaxableName: "Không chịu thuế", TaxableID: 1 },
      ],
      // ẩn contextmenu
      hiddenContextMenu: true,
      // ẩn box btn
      hiddenBoxBtn: true,
      // mode để check trạng thái form
      mode: 0,
      // ID  thành phần lương
      salaryCompositionID: "",
      // Thành phần lương
      salaryComposition: {},
      // check trùng mã
      isDuplicate: false,
      // mảng thành phần lương
      salaryCompositions: [],
    };
  },
  created() {
    // lấy danh sách loại thành phần
    this.getSalaryCompositionType();
    // lấy ra toàn bộ danh sách thành phần lương
    this.getSalaryComposition();
  },
  mounted() {
    document.addEventListener("click", this.close);
  },
  methods: {
    /**--------------------------------------------
     * Hàm check mode
     * CreateBy : LQNHAT(21/09/2021)
     */
    show(mode, id) {
      this.mode = mode;
      this.salaryCompositionID = id;
      if (mode == 0) {
        this.salaryComposition = {
          OrganizationUnitID: "c0ff752c-5ff4-4238-998b-4235c9818b00",
          NatureID: 1,
          TaxableID: 0,
        };
        this.$nextTick(() => this.$refs.salaryCompositionName.focus());
      }
      // mode == 1 thì bind data lên form
      else {
        this.bindDataToForm();
      }
    },

    /**-----------------------------------------------------------------------
     * Bắt sự kiện click nút lưu
     * CreatedBy: LQNHAT(21/09/2021)
     */
    saveBtnClick() {
      // validate check trùng mã
      if (this.isDuplicate == true) {
        this.$toast.error("Mã thành phần đã tồn tại", {
          timeout: 2000,
        });
        this.isDuplicate = false;
        return;
      }
      // validate cả form
      this.$refs.form_salary.validate().then((success) => {
        if (!success) {
          return;
        }
        if (this.mode == 0) {
          this.addSalaryComposition();
          this.salaryComposition = {
            OrganizationUnitID: "c0ff752c-5ff4-4238-998b-4235c9818b00",
            NatureID: 1,
          };
          this.closeFormDetail();
        }
      });
    },

    /**-------------------------------------------------------
     * Lấy ra toàn bộ danh sách thành phần lương
     * CreatedBy: LQNHAT(21/09/2021)
     */
    getSalaryComposition() {
      var self = this;
      axios.get(URL_API.API_SALARYCOMPOSITION).then((res) => {
        self.salaryCompositions = res.data;
        console.log(self.salaryCompositions);
      });
    },

    /**------------------------------------------------------
     * Check trùng mã
     * CreatedBy: LQNHAT(21/09/2021)
     */
    checkDuplicateCode() {
      this.salaryCompositions.forEach((element) => {
        if (
          this.salaryComposition.SalaryCompositionCode ==
            element.SalaryCompositionCode &&
          this.salaryComposition.SalaryCompositionID !=
            element.SalaryCompositionID
        ) {
          this.isDuplicate = true;
        }
      });
    },

    /**----------------------------------------------------------------------
     * Thêm mới thành phần lương
     * CreatedBy: LQNHAT(21/09/2021)
     */
    addSalaryComposition() {
      var self = this;
      axios
        .post(URL_API.API_SALARYCOMPOSITION, self.salaryComposition)
        .then(() => {
          self.$emit("reloadTableAndFilter");
          self.$toast.success("Thêm thành phần lương thành công", {
            timeout: 2000,
          });
        });
    },

    /**----------------------------------------------------------------------------
     * Lấy ra toàn bộ danh sách loại thành phần
     * CreatedBy: LQNHAT(21/09/2021)
     */
    getSalaryCompositionType() {
      var self = this;
      axios.get(URL_API.API_SALARYCOMPOSITIONTYPE).then((res) => {
        self.dataSourceType = res.data;
      });
    },

    /**-------------------------------------------------------------------------
     * Bind dữ liệu lên trên form
     * CreatedBy: LQNHAT(21/09/2021)
     */
    bindDataToForm() {
      var self = this;
      axios
        .get(URL_API.API_SALARYCOMPOSITION + "/" + self.salaryCompositionID)
        .then((res) => {
          self.salaryComposition = res.data;
        });
    },

    /**------------------------------------------------------------------------------
     * Sự kiện click nút <-
     * CreatedBy: LQNHAT(15/09/2021)
     */
    closeFormDetail() {
      // close form
      this.$emit("closeForm");
      this.$refs.form_salary.reset();
      console.log(
        "salaryComposition.OrganizationUnitID: " +
          this.salaryComposition.OrganizationUnitID
      );
    },

    /**-------------------------------------------------------
     * Bắt sự kiện toggle contextmenu
     * CreatedBy: LQNHAT(21/09/2021)
     */
    toggleContextMenu() {
      this.hiddenContextMenu = !this.hiddenContextMenu;
    },

    /*------------------------------------------------------------------
     * Bắt sự kiện close box btn
     * CreatedBy: LQNHAT(21/09/2021)
     */
    closeBoxBtn() {
      this.hiddenBoxBtn = true;
    },

    /*------------------------------------------------------------------
     * Bắt sự kiện open box btn
     * CreatedBy: LQNHAT(21/09/2021)
     */
    openBoxBtn() {
      this.hiddenBoxBtn = false;
      this.$nextTick(() => this.$refs.salaryCompositionName.focus());
    },

    /**----------------------------------------------------------------------
     * Hàm check event khi click ra bên ngoài context
     * CreateBy: LQNhat(21/09/2021)
     */
    close(e) {
      if (!this.$el.contains(e.target)) {
        this.hiddenContextMenu = true;
      }
    },
  },
};
</script>

<style>
</style>