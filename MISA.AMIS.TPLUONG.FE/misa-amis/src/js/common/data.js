export const URL_API = {
  API_SALARYCOMPOSITION : "https://localhost:44307/api/v1/SalaryCompositions",
}

export const TYPE = [
    {TypeName: "Thông tin nhân viên", TypeID: 1},
    {TypeName: "Chấm công", TypeID: 2},
    {TypeName: "Doanh số", TypeID: 3},
    {TypeName: "KPI", TypeID: 4},
    {TypeName: "Sản phẩm", TypeID: 5},
    {TypeName: "Lương", TypeID: 6},
    {TypeName: "Thuế TNCN", TypeID: 7},
    {TypeName: "Bảo hiểm Công Đoàn", TypeID: 8},
    {TypeName: "Khác", TypeID: 9},
]

export const NATURE = [
    {NatureName: "Thu nhập", NatureID: 1},
    {NatureName: "Khấu trừ", NatureID: 2},
    {NatureName: "Khác", NatureID: 3},
]

export const VALUE_TYPE = [
    {ValueTypeName: "Tiền tệ", ValueTypeID: 1},
]

export const TREE_DATA_SOURCE =  [
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
    }
  ]

  export const TREE_DATA_SOURCE_FILTER =  [
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
    
  ]