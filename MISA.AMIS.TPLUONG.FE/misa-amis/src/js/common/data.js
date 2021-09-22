export const URL_API = {
  API_SALARYCOMPOSITION: "https://localhost:44307/api/v1/SalaryCompositions",
  API_ORGANIZATIONUNIT: "https://localhost:44307/api/v1/OrganizationUnits",
  API_SALARYCOMPOSITIONTYPE:
    "https://localhost:44307/api/v1/SalaryCompositionTypes",
};

export const TYPE = [
  { TypeName: "Thông tin nhân viên", TypeID: 1 },
  { TypeName: "Chấm công", TypeID: 2 },
  { TypeName: "Doanh số", TypeID: 3 },
  { TypeName: "KPI", TypeID: 4 },
  { TypeName: "Sản phẩm", TypeID: 5 },
  { TypeName: "Lương", TypeID: 6 },
  { TypeName: "Thuế TNCN", TypeID: 7 },
  { TypeName: "Bảo hiểm Công Đoàn", TypeID: 8 },
  { TypeName: "Khác", TypeID: 9 },
];

export const NATURE = [
  { NatureName: "Thu nhập", NatureID: 1 },
  { NatureName: "Khấu trừ", NatureID: 2 },
  { NatureName: "Khác", NatureID: 3 },
];

export const VALUE_TYPE = [
  { ValueTypeName: "Số", ValueTypeID: 1 },
  { ValueTypeName: "Tiền tệ", ValueTypeID: 2 },
  { ValueTypeName: "Phần trăm", ValueTypeID: 3 },
  { ValueTypeName: "Chữ", ValueTypeID: 4 },
  { ValueTypeName: "Ngày", ValueTypeID: 5 },
];

export const FILTER = [
  { FilterName: "Chứa", FilterID: 1 },
  { FilterName: "Không chứa", FilterID: 2 },
  { FilterName: "Bằng", FilterID: 3 },
  { FilterName: "Bắt đầu bằng", FilterID: 4 },
  { FilterName: "Kết thúc bằng", FilterID: 5 },
  { FilterName: "Trống", FilterID: 6 },
  { FilterName: "Không trống", FilterID: 7 },
];

export const TREE_DATA_SOURCE = [
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
  {
    OrganizationUnitID: 6,
    OrganizationUnitName: "Phòng nhân sự",
    ParentID: 1,
  },
];

export const HEADERS = [
  {
    DataField: "SalaryCompositionCode",
    Caption: "Mã thành phần",
    DataType: "text",
    Alignment: "left",
    Fixed: true,
    Checked: false,
  },
  {
    DataField: "SalaryCompositionName",
    Caption: "Tên thành phần",
    DataType: "text",
    Alignment: "left",
    Fixed: true,
    Checked: false,
  },
  {
    DataField: "SalaryCompositionTypeName",
    Caption: "Loại thành phần",
    DataType: "text",
    Alignment: "left",
    Fixed: false,
    Checked: false,
  },
  {
    DataField: "NatureName",
    Caption: "Tính chất",
    DataType: "text",
    Alignment: "left",
    Fixed: false,
    Checked: false,
  },
  {
    DataField: "OrganizationUnitName",
    Caption: "Đơn vị áp dụng",
    DataType: "text",
    Alignment: "left",
    Fixed: false,
    Checked: false,
  },
  {
    DataField: "TaxableName",
    Caption: "Chịu thuế",
    DataType: "text",
    Alignment: "left",
    Fixed: false,
    Checked: false,
  },
  {
    DataField: "ReduceName",
    Caption: "Giảm trừ khi tính thuế",
    DataType: "text",
    Alignment: "left",
    Fixed: false,
    Checked: false,
  },
  {
    DataField: "Quota",
    Caption: "Định mức",
    DataType: "text",
    Alignment: "right",
    Fixed: false,
    Checked: false,
  },
  {
    DataField: "Cost",
    Caption: "Giá trị",
    DataType: "text",
    Alignment: "left",
    Fixed: false,
    Checked: false,
  },
  {
    DataField: "Description",
    Caption: "Mô tả",
    DataType: "text",
    Alignment: "left",
    Fixed: false,
    Checked: false,
  },
  {
    DataField: "StatusName",
    Caption: "Trạng thái",
    DataType: "text",
    Alignment: "left",
    Fixed: false,
    Checked: false,
  },
]

export const STATUS_DATA = [
  { Text: "Tất cả trạng thái", Value: "" },
  { Text: "Đang theo dõi", Value: 0 },
  { Text: "Ngừng theo dõi", Value: 1 },
]

export const PAGE_DATA =  [
  { Text: "15", Value: 15 },
  { Text: "25", Value: 25 },
  { Text: "50", Value: 50 },
  { Text: "100", Value: 100 },
]