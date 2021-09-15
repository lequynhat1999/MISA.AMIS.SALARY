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
      <div class="box-search relative">
        <input
          type="text"
          class="m-input input-search"
          placeholder="Tìm kiếm"
        />
        <div class="icon-search"></div>
      </div>
      <div class="toolbar-right flex">
        <BaseDropdownSingle style="margin-right: 20px;width: 316px"
          :treeDataSource="treeDataSource"
          :placeholderProp = "'Tất cả đơn vị'"
          :valueExprProp = "'OrganizationUnitID'"
          :displayExprProp = "'OrganizationUnitName'"
          :parentIdExprProp = "'ParentID'"
          :valueDefault = treeDataSource[0].OrganizationUnitID
         />
        <div class="box-filter-toolbar">
          <div class="icon-filter-toolbar"></div>
        </div>
        <div class="box-setting-toolbar">
          <div class="icon-setting-toolbar"></div>
        </div>
      </div>
    </div>
    <div class="table-salary">
      <BaseGrid 
        :headers="headers"
        :dataSource="dataSource"
       >
       <template #Status ="{data}">
         <div class="box-status flex a-l-c">
           <div class="icon-status"></div>
           <div class="text-status">{{data.Status}}</div>
         </div>
       </template>
       </BaseGrid>

      <div class="paging">
        <div class="amount">Tổng số bản ghi: <b>175</b></div>
      </div>
    </div>
    <SalaryDetail 
      :isOpenModal="isOpenModal"
      @closeForm="closeForm"
    />
  </div>
</template>

<script>
import TitleSalary from "../../components/base/BaseTitle.vue";
// import BaseDropdown from "../../components/base/BaseDropdown.vue";
import BaseDropdownSingle from "../../components/base/BaseDropdownSingle.vue";
import BaseGrid from "../../components/base/BaseGrid.vue";
import SalaryDetail from "../salary/SalaryDetail.vue";
export default {
  name: "SalaryList",
  components: {
    TitleSalary,
    // BaseDropdown,
    BaseDropdownSingle,
    BaseGrid,
    SalaryDetail,
  },
  data() {
    return {
      // mở modal
      isOpenModal: true,
      // data source treeview
      treeDataSource: [
            {
              OrganizationUnitID: 1,
              OrganizationUnitName: "Công ty cổ phần MISA",
              ParentID: 0,
            },
            {
              OrganizationUnitID: 2,
              OrganizationUnitName: "Phòng đào tạo",
              ParentID: 1,
            },
            {
              OrganizationUnitID: 3,
              OrganizationUnitName: "Phòng công nghệ",
              ParentID: 1,
            },
            {
              OrganizationUnitID: 5,
              OrganizationUnitName: "Phòng kế toán",
              ParentID: 2,
            },
            {
              OrganizationUnitID: 4,
              OrganizationUnitName: "Phòng hành chính",
              ParentID: 3,
            },
            
          ],
      // data source grid
      dataSource: [
        {
          SalaryCompositionID : 0,
          SalaryCompositionCode: "LUONG_SAN_PHAM",
          SalaryCompositionName: "Lương sản phẩm",
          ApplicableUnit: "Công ty TNHH Kim Đồng",
          IngredientType: "Sản phẩm",
          Nature: "Khấu trừ",
          Price: "Tiền tệ",
          Status: "Đang hoạt động"
        },
        {
          SalaryCompositionID : 1,
          SalaryCompositionCode: "LUONG_SAN_PHAM",
          SalaryCompositionName: "Lương sản phẩm",
          ApplicableUnit: "Công ty TNHH Kim Long",
          IngredientType: "Sản phẩm",
          Nature: "Khấu trừ",
          Price: "Tiền tệ",
          Status: "Đang hoạt động"
        },
        {
          SalaryCompositionID : 2,
          SalaryCompositionCode: "LUONG_SAN_PHAM",
          SalaryCompositionName: "Lương sản phẩm",
          ApplicableUnit: "Công ty TNHH Kim Đồng",
          IngredientType: "Sản phẩm",
          Nature: "Khấu trừ",
          Price: "Tiền tệ",
          Status: "Đang hoạt động"
        },
        {
          SalaryCompositionID : 3,
          SalaryCompositionCode: "LUONG_SAN_PHAM",
          SalaryCompositionName: "Lương sản phẩm",
          ApplicableUnit: "Công ty TNHH Kim Đồng",
          IngredientType: "Sản phẩm",
          Nature: "Khấu trừ",
          Price: "Tiền tệ",
          Status: "Đang hoạt động"
        },
        {
          SalaryCompositionID : 4,
          SalaryCompositionCode: "LUONG_SAN_PHAM",
          SalaryCompositionName: "Lương sản phẩm",
          ApplicableUnit: "Công ty TNHH Kim Đồng",
          IngredientType: "Sản phẩm",
          Nature: "Khấu trừ",
          Price: "Tiền tệ",
          Status: "Đang hoạt động"
        },
        {
          SalaryCompositionID : 5,
          SalaryCompositionCode: "LUONG_SAN_PHAM",
          SalaryCompositionName: "Lương sản phẩm",
          ApplicableUnit: "Công ty TNHH Kim Đồng",
          IngredientType: "Sản phẩm",
          Nature: "Khấu trừ",
          Price: "Tiền tệ",
          Status: "Đang hoạt động"
        },
        {
          SalaryCompositionID : 6,
          SalaryCompositionCode: "LUONG_SAN_PHAM",
          SalaryCompositionName: "Lương sản phẩm",
          ApplicableUnit: "Công ty TNHH Kim Đồng",
          IngredientType: "Sản phẩm",
          Nature: "Khấu trừ",
          Price: "Tiền tệ",
          Status: "Đang hoạt động"
        },
        {
          SalaryCompositionID : 7,
          SalaryCompositionCode: "LUONG_SAN_PHAM",
          SalaryCompositionName: "Lương sản phẩm",
          ApplicableUnit: "Công ty TNHH Kim Đồng",
          IngredientType: "Sản phẩm",
          Nature: "Khấu trừ",
          Price: "Tiền tệ",
          Status: "Đang hoạt động"
        },
        {
          SalaryCompositionID : 8,
          SalaryCompositionCode: "LUONG_SAN_PHAM",
          SalaryCompositionName: "Lương sản phẩm",
          ApplicableUnit: "Công ty TNHH Kim Đồng",
          IngredientType: "Sản phẩm",
          Nature: "Khấu trừ",
          Price: "Tiền tệ",
          Status: "Đang hoạt động"
        },
        {
          SalaryCompositionID : 9,
          SalaryCompositionCode: "LUONG_SAN_PHAM",
          SalaryCompositionName: "Lương sản phẩm",
          ApplicableUnit: "Công ty TNHH Kim Đồng",
          IngredientType: "Sản phẩm",
          Nature: "Khấu trừ",
          Price: "Tiền tệ",
          Status: "Đang hoạt động"
        },
        {
          SalaryCompositionID : 10,
          SalaryCompositionCode: "LUONG_SAN_PHAM",
          SalaryCompositionName: "Lương sản phẩm",
          ApplicableUnit: "Công ty TNHH Kim Đồng",
          IngredientType: "Sản phẩm",
          Nature: "Khấu trừ",
          Price: "Tiền tệ",
          Status: "Đang hoạt động"
        },
      ],
      // header grid
      headers : [
        {
          DataField: "SalaryCompositionCode",
          Caption: "Mã thành phần",
          DataType: "text",
          Alignment: "left",
          Fixed: true,
        },
        {
          DataField: "SalaryCompositionName",
          Caption: "Tên thành phần",
          DataType: "text",
          Alignment: "left",
          Fixed: true,
        },
        {
          DataField: "ApplicableUnit",
          Caption: "Đơn vị áp dụng",
          DataType: "text",
          Alignment: "left",
          Fixed: false,
        },
        {
          DataField: "IngredientType",
          Caption: "Loại thành phần",
          DataType: "text",
          Alignment: "left",
          Fixed: false,
        },
        {
          DataField: "Nature",
          Caption: "Tính chất",
          DataType: "text",
          Alignment: "left",
          Fixed: false,
        },
        {
          DataField: "Price",
          Caption: "Giá trị",
          DataType: "text",
          Alignment: "left",
          Fixed: false,
        },
        {
          DataField: "Status",
          Caption: "Trạng thái",
          DataType: "text",
          Alignment: "left",
          Fixed: false,
        },
      ]
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